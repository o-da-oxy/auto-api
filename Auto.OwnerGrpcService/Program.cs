using Auto.Data;
using Auto.OwnerGrpcService.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
builder.Services.AddSingleton<IAutoDatabase, AutoCsvFileDatabase>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<OwnerService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.Run();