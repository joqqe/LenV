using LenV.Demo.Application;
using LenV.Demo.Application.Common.Interfaces;
using LenV.Demo.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api3", Version = "v1" });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "LenV.Demo.MinApi.xml"));
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

});
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

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

app.MapGet("/customers", async (ICustomerService customerService) =>
{
    return await customerService.GetAllAsync();
})
.WithName("GetCustomers");

app.Run();
