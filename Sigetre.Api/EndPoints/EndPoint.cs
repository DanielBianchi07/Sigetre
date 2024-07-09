using Sigetre.Api.Common.Api;
using Sigetre.Api.EndPoints.Alternatives;

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
    }
    
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}