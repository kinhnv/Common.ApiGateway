using Ocelot.Middleware;
using Ocelot.ClientGateway;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddClientGatewayOcelot();

var app = builder.Build();

app.UseOcelot().Wait();

app.Run();
