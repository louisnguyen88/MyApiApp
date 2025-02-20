using Amazon.Lambda;
using Amazon.SecretsManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MyApiApp.Services;

var builder = WebApplication.CreateBuilder(args);

// AWS Service Registrations
builder.Services.AddAWSService<IAmazonLambda>();
builder.Services.AddAWSService<IAmazonSecretsManager>();
builder.Services.AddSingleton<SecretManagerService>();
builder.Services.AddSingleton<ILambdaService, LambdaService>();

// Add Controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.Run();
