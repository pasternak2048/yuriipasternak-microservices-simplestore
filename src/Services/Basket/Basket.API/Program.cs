var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

// Add Services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.Run();
