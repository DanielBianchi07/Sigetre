using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Data;
using Sigetre.Api.Handlers;
using Sigetre.Api.Models;
using Sigetre.Core;
using Sigetre.Core.Handlers;

namespace Sigetre.Api.Common.Api;

public static class BuildExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection2") ?? string.Empty;
        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(n => n.FullName));
    }

    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies(o => { });

        builder.Services.AddIdentityCore<User>(o =>
            {
                o.Stores.MaxLengthForKeys = 128;
                o.SignIn.RequireConfirmedAccount = true;
            })
            .AddDefaultTokenProviders();
        
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAuthorization(o =>
        {
            o.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            o.AddPolicy("RequireAdministratorRole", 
                x=>x.RequireRole("Administrator"));
        });
        
    }
    
    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(
            x =>
            {
                x.UseSqlServer(Configuration.ConnectionString);
            });
        builder.Services
            .AddIdentityCore<User>(o =>
            {
                o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                o.Lockout.MaxFailedAccessAttempts = 5;
                o.Lockout.AllowedForNewUsers = true;
            })
            .AddRoles<IdentityRole<long>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddApiEndpoints();
    }

    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        // CORS
        builder.Services.AddCors(
            options => options.AddPolicy(ApiConfiguration.CorsPolicyName,
                policy => policy
                    .WithOrigins([
                    Configuration.BackendUrl, 
                    Configuration.FrontendUrl
                    ])
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            ));
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAddressHandler, AddressesHandler>();
        builder.Services.AddTransient<IAlternativeHandler, AlternativeHandler>();
        builder.Services.AddTransient<IAttendanceListHandler, AttendanceListHandler>();
        builder.Services.AddTransient<ICompanyHandler, CompanyHandler>();
        builder.Services.AddTransient<IClientHandler, ClientHandler>();
        builder.Services.AddTransient<ICourseHandler, CourseHandler>();
        builder.Services.AddTransient<IInstructorHandler, InstructorHandler>();
        builder.Services.AddTransient<IPhoneHandler, PhoneHandler>();
        builder.Services.AddTransient<IProgramContentHandler, ProgramContentHandler>();
        builder.Services.AddTransient<IQuestionHandler, QuestionHandler>();
        builder.Services.AddTransient<ISpecializationHandler, SpecializationHandler>();
        builder.Services.AddTransient<IStudentHandler, StudentHandler>();
        builder.Services.AddTransient<ITestHandler, TestHandler>();
        builder.Services.AddTransient<ITrainingHandler, TrainingHandler>();
    }
}