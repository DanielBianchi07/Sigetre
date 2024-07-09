using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sigetre.Api.Models;
using Sigetre.Core.Models;

namespace Sigetre.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : IdentityDbContext
        <
            User, 
            IdentityRole<long>, 
            long, 
            IdentityUserClaim<long>, 
            IdentityUserRole<long>, 
            IdentityUserLogin<long>,
            IdentityRoleClaim<long>,
            IdentityUserToken<long>
        >(options)
{
    public DbSet<Alternative> Alternatives { get; set; }
    public DbSet<AttendanceList> AttendanceLists { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyAddress> CompanyAddresses { get; set; }
    public DbSet<CompanyPhone> CompanyPhones { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<ProgramContent> ProgramContents { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<InstructorCourse> InstructorCourses { get; set; }

    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
