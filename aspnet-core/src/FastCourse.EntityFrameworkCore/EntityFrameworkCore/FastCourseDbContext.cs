using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FastCourse.Authorization.Roles;
using FastCourse.Authorization.Users;
using FastCourse.MultiTenancy;

namespace FastCourse.EntityFrameworkCore
{
    public class FastCourseDbContext : AbpZeroDbContext<Tenant, Role, User, FastCourseDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public FastCourseDbContext(DbContextOptions<FastCourseDbContext> options)
            : base(options)
        {
        }
    }
}
