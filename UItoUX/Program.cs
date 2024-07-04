using Microsoft.OpenApi.Models;
using System.Reflection;
using UItoUX.DBEngine;
using UItoUX.Repository.Interface;
using UItoUX.Repository.Repository;
using UItoUX.Service.Interface;
using UItoUX.Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "UItoUX API",
        Version = "v1",
        Description = "API documentation for UItoUX"
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


//registers

builder.Services.AddSingleton<IDapperHandler, DapperHandler>();
builder.Services.AddTransient<IHomePageRepository, HomePageRepository>();
builder.Services.AddTransient<IHomePageService, HomePageService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
