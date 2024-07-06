using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigetre.Core.Models;

namespace Sigetre.Api.Data.Mappings;

public class InstructorCourseMapping : IEntityTypeConfiguration<InstructorCourse>
{
    public void Configure(EntityTypeBuilder<InstructorCourse> builder)
    {
        builder.ToTable("InstructorCourses");

        builder.HasKey(x => new
        {
            x.InstructorId, x.CourseId
        });

        builder.HasOne<Instructor>(x => x.Instructor)
            .WithMany(x => x.InstructorCourses)
            .HasForeignKey(x => x.InstructorId);

        builder.HasOne<Course>(x => x.Course)
            .WithMany(x => x.InstructorCourses)
            .HasForeignKey(x => x.CourseId);

        builder.Property(x => x.TechnicalManager)
            .IsRequired(true);
    }
}