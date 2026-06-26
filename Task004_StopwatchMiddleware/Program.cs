using Scalar.AspNetCore;
using Serilog;
using Task004_StopwatchMiddleware;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Services.AddOpenApi();
builder.Services.AddLogging(loggingBuilder => { loggingBuilder.AddSerilog(Log.Logger, true); });
builder.Services.AddTransient<StopwatchMiddleware>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.AddEndpoints();

app.UseHttpsRedirection();

app.UseMiddleware<StopwatchMiddleware>();

app.UseRouting();

app.Run();