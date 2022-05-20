using CleanArchitecture.DotNet6.API.IntegrationTests.Base;
using Xunit;

namespace CleanArchitecture.DotNet6.API.IntegrationTests
{
    [CollectionDefinition(nameof(IntegrationTestServerCollectionFixture))]
    public class IntegrationTestServerCollectionFixture : ICollectionFixture<CustomWebApplicationFactory<Program>> { }
}
