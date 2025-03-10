using Sigetre.Api.Common.Api;
using Sigetre.Api.EndPoints.Addresses;
using Sigetre.Api.EndPoints.Alternatives;
using Sigetre.Api.EndPoints.AttendanceLists;
using Sigetre.Api.EndPoints.Companies;
using Sigetre.Api.EndPoints.Instructors;
using Sigetre.Api.EndPoints.Courses;
using Sigetre.Api.Models;

using Sigetre.Api.EndPoints.Identity;
using Sigetre.Api.EndPoints.Phones;
using Sigetre.Api.EndPoints.ProgramContents;
using Sigetre.Api.EndPoints.Questions;
using Sigetre.Api.EndPoints.Specializations;
using Sigetre.Api.EndPoints.Students;
using Sigetre.Api.EndPoints.Tests;
using Sigetre.Api.EndPoints.Trainings;


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
            .MapEndpoint<GetAddressByCompanyEndpoint>();

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
            .MapEndpoint<GetRolesEndpoint>();
        
        endpoints.MapGroup("v1/instructors")
            .WithTags("Instructors")
            .RequireAuthorization()
            .MapEndpoint<CreateInstructorEndpoint>()
            .MapEndpoint<UpdateInstructorEndpoint>()
            .MapEndpoint<DeleteInstructorEndpoint>()
            .MapEndpoint<GetInstructorByIdEndpoint>()
            .MapEndpoint<GetInstructorBySpecializationEndpoint>()
            .MapEndpoint<GetAllInstructorEndpoint>();

        endpoints.MapGroup("v1/phones")
            .WithTags("Phones")
            .RequireAuthorization()
            .MapEndpoint<CreatePhoneEndpoint>()
            .MapEndpoint<UpdatePhoneEndpoint>()
            .MapEndpoint<DeletePhoneEndpoint>()
            .MapEndpoint<GetPhoneByCompanyEndpoint>();

        endpoints.MapGroup("v1/programContents")
            .WithTags("ProgramContents")
            .RequireAuthorization()
            .MapEndpoint<CreateProgramContentEndpoint>()
            .MapEndpoint<UpdateProgramContentEndpoint>()
            .MapEndpoint<DeleteProgramContentEndpoint>()
            .MapEndpoint<GetProgramContentByIdEndpoint>()
            .MapEndpoint<GetProgramContentByCourseEndpoint>();
        
        endpoints.MapGroup("v1/questions")
            .WithTags("Questions")
            .RequireAuthorization()
            .MapEndpoint<CreateQuestionEndpoint>()
            .MapEndpoint<UpdateQuestionEndpoint>()
            .MapEndpoint<DeleteQuestionEndpoint>()
            .MapEndpoint<GetQuestionByIdEndpoint>()
            .MapEndpoint<GetQuestionByCourseEndpoint>();
        
        endpoints.MapGroup("v1/specializations")
            .WithTags("Specializations")
            .RequireAuthorization()
            .MapEndpoint<CreateSpecializationEndpoint>()
            .MapEndpoint<UpdateSpecializationEndpoint>()
            .MapEndpoint<DeleteSpecializationEndpoint>()
            .MapEndpoint<GetSpecializationByIdEndpoint>()
            .MapEndpoint<GetAllSpecializationEndpoint>();
        
        endpoints.MapGroup("v1/students")
            .WithTags("Students")
            .RequireAuthorization()
            .MapEndpoint<CreateStudentEndpoint>()
            .MapEndpoint<UpdateStudentEndpoint>()
            .MapEndpoint<DeleteStudentEndpoint>()
            .MapEndpoint<GetStudentByIdEndpoint>()
            .MapEndpoint<GetAllStudentEndpoint>();

        endpoints.MapGroup("v1/tests")
            .WithTags("Tests")
            .RequireAuthorization()
            .MapEndpoint<CreateTestEndpoint>()
            .MapEndpoint<UpdateTestEndpoint>()
            .MapEndpoint<DeleteTestEndpoint>()
            .MapEndpoint<GetTestByIdEndpoint>();

        endpoints.MapGroup("v1/trainings")
            .WithTags("Trainings")
            .RequireAuthorization()
            .MapEndpoint<CreateTrainingEndpoint>()
            .MapEndpoint<UpdateTrainingEndpoint>()
            .MapEndpoint<DeleteTrainingEndpoint>()
            .MapEndpoint<GetTrainingByIdEndpoint>()
            .MapEndpoint<GetAllTrainingEndpoint>()
            .MapEndpoint<GetTrainingByCourseEndpoint>()
            .MapEndpoint<GetTrainingByDateEndpoint>()
            .MapEndpoint<GetTrainingByInstructorEndpoint>()
            .MapEndpoint<GetTrainingByStudentEndpoint>();
    }
    
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}