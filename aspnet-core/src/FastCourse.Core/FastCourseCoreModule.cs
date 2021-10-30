using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using FastCourse.Authorization.Roles;
using FastCourse.Authorization.Users;
using FastCourse.Configuration;
using FastCourse.Localization;
using FastCourse.MultiTenancy;
using FastCourse.Timing;

namespace FastCourse
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class FastCourseCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            FastCourseLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            //Configuration.MultiTenancy.IsEnabled = FastCourseConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = FastCourseConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = FastCourseConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FastCourseCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
