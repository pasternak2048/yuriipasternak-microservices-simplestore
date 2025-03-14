using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.
builder.Services.AddApplicationServices()
	.AddInfrastructureServices(builder.Configuration)
	.AddApiServices(builder.Configuration);

var app = builder.Build();

//Configure the HTTP request pipeline.
app.UseApiServices();

app.Run();
