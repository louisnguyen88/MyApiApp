using Amazon.Lambda;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MyApiApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Load AWS Configurations
builder.Services.AddAWSService<IAmazonLambda>();
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
