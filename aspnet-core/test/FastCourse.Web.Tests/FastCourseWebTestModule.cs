using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FastCourse.EntityFrameworkCore;
using FastCourse.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace FastCourse.Web.Tests
{
    [DependsOn(
        typeof(FastCourseWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class FastCourseWebTestModule : AbpModule
    {
        public FastCourseWebTestModule(FastCourseEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FastCourseWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(FastCourseWebMvcModule).Assembly);
        }
    }
}