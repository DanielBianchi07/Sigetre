using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Api.EndPoints;
using Sigetre.Api.Handlers;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection2") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(
    x => { x.UseSqlServer(cnnStr); }
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(n => n.FullName));
builder.Services.AddTransient<ICompanyHandler, CompanyHandler>();
builder.Services.AddTransient<IAlternativeHandler, AlternativeHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => new { message = "OK" });
app.MapEndpoints();

app.Run();
