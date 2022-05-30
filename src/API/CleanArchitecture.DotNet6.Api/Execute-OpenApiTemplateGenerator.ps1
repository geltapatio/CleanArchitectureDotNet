param([string]$configuration="Debug")

Write-Host "Getting openapi configuration"
$SwaggerJsonFilePath = "swagger.json"
$AngularClientSourceFolderPath = "generated-angular-client"
$GeneratedClientApiDestinationFolderPath = "ClientApp\\src\\app\\openapi"
$OpenApiGeneratorCliVersion = "4.3.1"
$ProjectNameDll = "CleanArchitecture.DotNet6.Api.dll"
$ErrorActionPreference = "Stop"

Function Ensure-EmptyDirectory($path) { 
    Write-Host "Ensure empty directory '$($path)'"
    New-Item -ItemType Directory -Force -Path $path | Out-Null
    Get-ChildItem -Path "$path" -Include * | remove-Item -recurse    
}

Write-Host "Ensure empty source and target folders"
Ensure-EmptyDirectory -Path $AngularClientSourceFolderPath
Ensure-EmptyDirectory -Path $GeneratedClientApiDestinationFolderPath

Write-Host "Remove generated swagger.json"
Remove-Item $SwaggerJsonFilePath -ErrorAction Ignore

Write-Host "Generate swagger.json"
dotnet swagger tofile --output swagger.json ./bin/$configuration/net6.0/$ProjectNameDll v1

Write-Host "Ensure openapi-generator-cli is installed"
npm install @openapitools/openapi-generator-cli -g

Write-Host "Set the version $($OpenApiGeneratorCliVersion) of openapi-generator-cli"
openapi-generator-cli version-manager set $OpenApiGeneratorCliVersion

Write-Host "Generate Angular client from swagger.json into clientApiDestinationPath"
openapi-generator-cli generate -g typescript-angular -i $SwaggerJsonFilePath -o $AngularClientSourceFolderPath --additional-properties=ngVersion=11.0.0 --type-mappings DateTime=Date

Write-Host "Copy generated Angular client from $($AngularClientSourceFolderPath) to $($GeneratedClientApiDestinationFolderPath)"
Copy-Item -Path "$($AngularClientSourceFolderPath)\*" -Destination $GeneratedClientApiDestinationFolderPath -Recurse -Container: $true
