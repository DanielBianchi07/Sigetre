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

#endregion

#region App

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => new { message = "OK" });
app.MapEndpoints();

app.MapGroup("v1/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.MapGroup("v1/identity")
    .WithTags("Identity")
    .MapPost("/logout", async (SignInManager<User> signInManager) =>
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    })
    .RequireAuthorization();

app.MapGroup("v1/identity")
    .WithTags("Identity")
    .MapPost("/roles", async (ClaimsPrincipal user) =>
    {
        if (user.Identity is null || !user.Identity.IsAuthenticated)
            return Results.Unauthorized();
        
        return Results.Ok();
    })
    .RequireAuthorization();

app.MapPost("/register", async (RegisterModel model, UserManager<User> userManager) =>
    {
        if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password) ||
            string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.PhoneNumber))
        {
            return Results.BadRequest("Todos os campos são obrigatórios.");
        }

        var user = new User
        {
            UserName = model.Email,
            Email = model.Email,
            Name = model.Name,
            PhoneNumber = model.PhoneNumber,
            ClientId = model.ClientId
            // Mapeie outros campos conforme necessário
        };
    
        var result = await userManager.CreateAsync(user, model.Password);
    
        if (result.Succeeded)
        {
            return Results.Ok("Usuário registrado com sucesso.");
        }

        return Results.BadRequest(result.Errors);
    });

app.Run();

#endregion