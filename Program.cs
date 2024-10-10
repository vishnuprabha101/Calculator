using Calculator.Interfaces;
using Calculator.Services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Calculator API", Version = "v1" });
});

builder.Services.AddTransient<ICalculatorService<int>, CalculatorService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculator API V1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();


app.MapGet("/api/add", ([FromQuery] int a, [FromQuery] int b, ICalculatorService<int> calculatorService) =>
{
    var result = calculatorService.Add(a, b);
    return Results.Ok(result);
})
.WithName("AddNumbers");

app.MapGet("/api/subtract", ([FromQuery] int a, [FromQuery] int b, ICalculatorService<int> calculatorService) =>
{
    var result = calculatorService.Subtract(a, b);
    return Results.Ok(result);
})
.WithName("SubtractNumbers");

app.MapGet("/api/multiply", ([FromQuery] int a, [FromQuery] int b, ICalculatorService<int> calculatorService) =>
{
    var result = calculatorService.Multiply(a, b);
    return Results.Ok(result);
})
.WithName("MultiplyNumbers");

app.MapGet("/api/divide", ([FromQuery] int a, [FromQuery] int b, ICalculatorService<int> calculatorService) =>
{
    if (b == 0)
        return Results.BadRequest("Cannot divide by zero.");
        
    var result = calculatorService.Divide(a, b);
    return Results.Ok(result);
})
.WithName("DivideNumbers");

app.Run();
