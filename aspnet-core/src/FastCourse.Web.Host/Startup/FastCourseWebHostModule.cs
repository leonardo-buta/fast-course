using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FastCourse.Configuration;

namespace FastCourse.Web.Host.Startup
{
    [DependsOn(
       typeof(FastCourseWebCoreModule))]
    public class FastCourseWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FastCourseWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FastCourseWebHostModule).GetAssembly());
        }
    }
}
