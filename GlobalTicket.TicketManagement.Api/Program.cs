using GlobalTicket.TicketManagement.Api.OeprationFilter;
using GloboTicket.TicketManagement.Api.Services;
using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Infrastructure;
using GloboTicket.TicketManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

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
var app = builder.Build();


app.UseHttpsRedirection();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GloboTicket Ticket Management API");
});
app.UseCors("Open");

app.UseAuthorization();

app.MapControllers();


app.Run();
public partial class Program { }
