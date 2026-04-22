using System.Diagnostics;
using WebApiImplementDI.Extensions;
using WebApiImplementDI.Services;
using WebApiImplementDI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Group registration
builder.Services.AddLifetimeServices();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var demoService = services.GetRequiredService<IDemoService>();
    var message = demoService.SayHello();
    Debug.WriteLine(message);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
