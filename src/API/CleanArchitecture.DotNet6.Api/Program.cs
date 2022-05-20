using CleanArchitecture.DotNet6.Api.Middleware;
using CleanArchitecture.DotNet6.Api.OperationFilter;
using CleanArchitecture.DotNet6.Api.Services;
using CleanArchitecture.DotNet6.Application;
using CleanArchitecture.DotNet6.Application.Contracts;
using CleanArchitecture.DotNet6.Infrastructure;
using CleanArchitecture.DotNet6.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add Serilog
Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
builder.Host.UseSerilog(((ctx, lc) => lc

.ReadFrom.Configuration(ctx.Configuration)));

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddPolicy("Open", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "GloboTicket Ticket Management API"
    });
    c.OperationFilter<FileResultContentTypeOperationFilter>();
}
);

builder.Services.AddSwaggerDocument(settings =>
{
    settings.PostProcess = document =>
    {
        document.Info.Version = "v1";
        document.Info.Title = "Example API";
        document.Info.Description = "REST API for example.";
    };
});

var app = builder.Build();


app.UseHttpsRedirection();
app.UseRouting();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GloboTicket Ticket Management API");
});
// Enable the Swagger UI middleware and the Swagger generator
app.UseOpenApi();
app.UseSwaggerUi3();

// Serilog
app.UseSerilogRequestLogging();

app.UseCustomExceptionHandler();

app.UseCors("Open");

app.UseAuthorization();

app.MapControllers();

app.Run();

#pragma warning disable CA1050 // Declare types in namespaces
public partial class Program { }
#pragma warning restore CA1050 // Declare types in namespaces
