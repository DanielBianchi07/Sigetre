using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Sigetre.Api.Common.Api;
using Sigetre.Api.EndPoints.Addresses;
using Sigetre.Api.EndPoints.Alternatives;
using Sigetre.Api.EndPoints.Clients;
using Sigetre.Api.EndPoints.Companies;
using Sigetre.Api.EndPoints.Instructors;
using Sigetre.Api.EndPoints.Courses;

using Sigetre.Api.Models;

namespace Sigetre.Api.EndPoints;

public static class Endpoint
{
    // Extension Method
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup("");

        endpoints.MapGroup("v1/addresses")
            .WithTags("Addresses")
            //.RequireAuthorization()
            .MapEndpoint<CreateAddressEndpoint>()
            .MapEndpoint<UpdateAddressEndpoint>()
            .MapEndpoint<DeleteAddressEndpoint>()
            .MapEndpoint<GetAddressByIdEndpoint>();

        endpoints.MapGroup("v1/alternatives")
            .WithTags("Alternatives")
            //.RequireAuthorization()
            .MapEndpoint<CreateAlternativeEndpoint>()
            .MapEndpoint<UpdateAlternativeEndpoint>()
            .MapEndpoint<DeleteAlternativeEndpoint>()
            .MapEndpoint<GetAlternativeByIdEndpoint>()
            .MapEndpoint<GetAlternativeByQuestionEndpoint>();
        
        endpoints.MapGroup("v1/companies")
            .WithTags("Companies")
            //.RequireAuthorization()
            .MapEndpoint<CreateCompanyEndpoint>()
            .MapEndpoint<UpdateCompanyEndpoint>()
            .MapEndpoint<DeleteCompanyEndpoint>()
            .MapEndpoint<GetCompanyByIdEndpoint>()
            .MapEndpoint<GetAllCompanyEndpoint>();
        
        endpoints.MapGroup("v1/instructors")
            .WithTags("Instructors")
            //.RequireAuthorization()
            .MapEndpoint<CreateInstructorEndpoint>()
            .MapEndpoint<UpdateInstructorEndpoint>()
            .MapEndpoint<DeleteInstructorEndpoint>()
            .MapEndpoint<GetInstructorByIdEndpoint>()
            .MapEndpoint<GetInstructorBySpecializationEndpoint>()
            .MapEndpoint<GetAllInstructorEndpoint>();
      
      endpoints.MapGroup("v1/clients")
            .WithTags("Clients")
            //.RequireAuthorization()
            .MapEndpoint<CreateClientEndpoint>()
            .MapEndpoint<UpdateClientEndpoint>()
            .MapEndpoint<DeleteClientEndpoint>()
            .MapEndpoint<GetClientByIdEndpoint>()
            .MapEndpoint<GetAllClientEndpoint>();
        
        endpoints.MapGroup("v1/courses")
            .WithTags("Courses")
            //.RequireAuthorization()
            .MapEndpoint<CreateCourseEndpoint>()
            .MapEndpoint<UpdateCourseEndpoint>()
            .MapEndpoint<DeleteCourseEndpoint>()
            .MapEndpoint<GetCourseByIdEndpoint>()
            .MapEndpoint<GetAllCourseEndpoint>();
        
        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapPost("/logout", async (SignInManager<User> signInManager) =>
            {
                await signInManager.SignOutAsync();
                return Results.Ok();
            })
            .RequireAuthorization();
        
        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapPost("/roles", (ClaimsPrincipal user) =>
            {
                if (user.Identity is null || !user.Identity.IsAuthenticated)
                    return Results.Unauthorized();
        
                return Results.Ok();
            })
            .RequireAuthorization();
        
        endpoints.MapPost("/register", async (RegisterModel model, UserManager<User> userManager) =>
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
                return Results.Ok(user);
            }

            return Results.BadRequest(result.Errors);
        });

    }
    
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}