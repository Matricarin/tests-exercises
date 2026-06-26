using Task004_StopwatchMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseMiddleware<StopwatchMiddleware>();
app.AddEndpoints();
app.Run();