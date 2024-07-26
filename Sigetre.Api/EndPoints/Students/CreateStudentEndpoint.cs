using System.Security.Claims;
using Sigetre.Api.Common.Api;
using Sigetre.Core.Handlers;
using Sigetre.Core.Models;
using Sigetre.Core.Requests.Student;
using Sigetre.Core.Responses;

namespace Sigetre.Api.EndPoints.Students;

public class CreateStudentEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Student: Create")
            .WithSummary("Create a new student")
            .WithDescription("Create a new student")
            .WithOrder(1)
            .Produces<Response<Student?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IStudentHandler handler,
        CreateStudentRequest request)
    {
        request.User = user.Identity?.Name ?? string.Empty;

        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}