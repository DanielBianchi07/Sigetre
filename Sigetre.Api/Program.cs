#region Imports

using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Api.EndPoints;
using Sigetre.Api.Handlers;
using Sigetre.Api.Models;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;

#endregion

#region Builder

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(n => n.FullName));

builder.Services
    .AddAuthentication(o=>
    {
        o.DefaultScheme = IdentityConstants.ApplicationScheme;
        o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies(o => { });
builder.Services.AddAuthorization();

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection2") ?? string.Empty;
var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(
    x => { x.UseSqlServer(cnnStr); }
);
builder.Services
    .AddIdentityCore<User>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

builder.Services.AddTransient<ICompanyHandler, CompanyHandler>();
builder.Services.AddTransient<IAlternativeHandler, AlternativeHandler>();
builder.Services.AddTransient<IAddressHandler, AddressesHandler>();
builder.Services.AddTransient<IClientHandler, ClientHandler>();
builder.Services.AddTransient<ICourseHandler, CourseHandler>();
builder.Services.AddTransient<IInstructorHandler, InstructorHandler>();

#endregion

#region App

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => new { message = "OK" });
app.MapEndpoints();

app.Run();

#endregion