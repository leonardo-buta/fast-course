using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FastCourse.Authorization.Roles;
using FastCourse.Authorization.Users;
using FastCourse.MultiTenancy;
using FastCourse.Courses;
using FastCourse.Questions;
using FastCourse.QuestionAlternatives;
using FastCourse.VideoLessons;
using FastCourse.Certificates;
using FastCourse.CertificateEmissions;
using FastCourse.VideoLessonsUserProgress;

namespace FastCourse.EntityFrameworkCore
{
    public class FastCourseDbContext : AbpZeroDbContext<Tenant, Role, User, FastCourseDbContext>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAlternative> QuestionAlternatives { get; set; }
        public DbSet<VideoLesson> VideoLessons { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CertificateEmission> CertificateEmissions { get; set; }
        public DbSet<VideoLessonUserProgress> VideoLessonsUserProgress { get; set; }

        public FastCourseDbContext(DbContextOptions<FastCourseDbContext> options)
            : base(options)
        {
        }
    }
}
