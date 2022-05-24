using LenV.Demo.Application;
using Microsoft.OpenApi.Models;
using LenV.Demo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MinApi", Version = "v1" });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "LenV.Demo.MinApi.xml"));
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

});

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseCustomerEndpoints();

app.Run();
