var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices(typeof(Program));

var app = builder.Build();

await app.Services.InitializeDatabasesAsync();

app.RegisterPipelineComponents(typeof(Program));