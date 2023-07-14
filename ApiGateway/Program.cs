using Ocelot.Middleware;
using Ocelot.ClientGateway;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddClientGatewayOcelot();

// Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
        builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowAll");

app.UseOcelot().Wait();

app.Run();
