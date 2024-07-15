using Sigetre.Api.Common.Api;
using Sigetre.Api.EndPoints.Alternatives;
using Sigetre.Api.EndPoints.Clients;
using Sigetre.Api.EndPoints.Companies;
using Sigetre.Api.EndPoints.Courses;

namespace Sigetre.Api.EndPoints;

public static class Endpoint
{
    // Extension Method
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup("");

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
    }
    
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}