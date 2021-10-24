﻿using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FastCourse.Authorization.Roles;
using FastCourse.Authorization.Users;
using FastCourse.MultiTenancy;
using FastCourse.Courses;

namespace FastCourse.EntityFrameworkCore
{
    public class FastCourseDbContext : AbpZeroDbContext<Tenant, Role, User, FastCourseDbContext>
    {
        public DbSet<Course> Course { get; set; }
        
        public FastCourseDbContext(DbContextOptions<FastCourseDbContext> options)
            : base(options)
        {
        }
    }
}
