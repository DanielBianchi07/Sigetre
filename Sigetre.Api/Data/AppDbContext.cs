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
    public DbSet<Alternative> Alternatives { get; set; } = null!;
    public DbSet<AttendanceList> AttendanceLists { get; set; } = null!;
    public DbSet<Certificate> Certificates { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Phones> CompanyPhones { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Instructor> Instructors { get; set; } = null!;
    public DbSet<ProgramContent> ProgramContents { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Specialization> Specializations { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Test> Tests { get; set; } = null!;
    public DbSet<Training> Trainings { get; set; } = null!;
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
