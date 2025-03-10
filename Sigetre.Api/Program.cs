using Sigetre.Api;
using Sigetre.Api.Common.Api;
using Sigetre.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddSecurity();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnviroment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.UseSecurity();
app.MapEndpoints();

app.Run();