using Sigetre.Api.Common.Api;
using Sigetre.Api.EndPoints.Addresses;
using Sigetre.Api.EndPoints.Alternatives;
using Sigetre.Api.EndPoints.AttendanceLists;
using Sigetre.Api.EndPoints.Clients;
using Sigetre.Api.EndPoints.Companies;
using Sigetre.Api.EndPoints.Instructors;
using Sigetre.Api.EndPoints.Courses;
using Sigetre.Api.Models;

using Sigetre.Api.EndPoints.Identity;


namespace Sigetre.Api.EndPoints;

public static class Endpoint
{
    // Extension Method
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup("");
        
        endpoints.MapGroup("")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" });
        

        endpoints.MapGroup("v1/addresses")
            .WithTags("Addresses")
            .RequireAuthorization()
            .MapEndpoint<CreateAddressEndpoint>()
            .MapEndpoint<UpdateAddressEndpoint>()
            .MapEndpoint<DeleteAddressEndpoint>()
            .MapEndpoint<GetAddressByIdEndpoint>();

        endpoints.MapGroup("v1/alternatives")
            .WithTags("Alternatives")
            .RequireAuthorization()
            .MapEndpoint<CreateAlternativeEndpoint>()
            .MapEndpoint<UpdateAlternativeEndpoint>()
            .MapEndpoint<DeleteAlternativeEndpoint>()
            .MapEndpoint<GetAlternativeByIdEndpoint>()
            .MapEndpoint<GetAlternativeByQuestionEndpoint>();
        
        endpoints.MapGroup("v1/attendancelists")
            .WithTags("AttendanceLists")
            .RequireAuthorization()
            .MapEndpoint<CreateAttendanceListEndpoint>()
            .MapEndpoint<UpdateAttendanceListEndpoint>()
            .MapEndpoint<DeleteAttendanceListEndpoint>()
            .MapEndpoint<GetAttendanceListByIdEndpoint>()
            .MapEndpoint<GetAllAttendanceListEndoint>();

        endpoints.MapGroup("v1/clients")
            .WithTags("Clients")
            .MapEndpoint<CreateClientEndpoint>();
            
        endpoints.MapGroup("v1/clients")
            .WithTags("Clients")
            .RequireAuthorization()
            .MapEndpoint<UpdateClientEndpoint>()
            .MapEndpoint<DeleteClientEndpoint>()
            .MapEndpoint<GetClientByIdEndpoint>()
            .MapEndpoint<GetAllClientEndpoint>();
        
        endpoints.MapGroup("v1/companies")
            .WithTags("Companies")
            .RequireAuthorization()
            .MapEndpoint<CreateCompanyEndpoint>()
            .MapEndpoint<UpdateCompanyEndpoint>()
            .MapEndpoint<DeleteCompanyEndpoint>()
            .MapEndpoint<GetCompanyByIdEndpoint>()
            .MapEndpoint<GetAllCompanyEndpoint>();

        endpoints.MapGroup("v1/courses")
            .WithTags("Courses")
            .RequireAuthorization()
            .MapEndpoint<CreateCourseEndpoint>()
            .MapEndpoint<UpdateCourseEndpoint>()
            .MapEndpoint<DeleteCourseEndpoint>()
            .MapEndpoint<GetCourseByIdEndpoint>()
            .MapEndpoint<GetAllCourseEndpoint>();
        
        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>();

        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapEndpoint<LogoutEndpoint>()
            .MapEndpoint<GetRolesEndpoint>()
            .MapEndpoint<InscribeEndpoint>();
        
        endpoints.MapGroup("v1/instructors")
            .WithTags("Instructors")
            .RequireAuthorization()
            .MapEndpoint<CreateInstructorEndpoint>()
            .MapEndpoint<UpdateInstructorEndpoint>()
            .MapEndpoint<DeleteInstructorEndpoint>()
            .MapEndpoint<GetInstructorByIdEndpoint>()
            .MapEndpoint<GetInstructorBySpecializationEndpoint>()
            .MapEndpoint<GetAllInstructorEndpoint>();
        
    }
    
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}