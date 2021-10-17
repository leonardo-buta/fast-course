using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FastCourse.Authorization;

namespace FastCourse
{
    [DependsOn(
        typeof(FastCourseCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FastCourseApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FastCourseAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FastCourseApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
