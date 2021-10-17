using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FastCourse.EntityFrameworkCore
{
    public static class FastCourseDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FastCourseDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FastCourseDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
