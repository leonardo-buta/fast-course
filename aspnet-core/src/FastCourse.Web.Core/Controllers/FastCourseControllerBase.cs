using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace FastCourse.Controllers
{
    public abstract class FastCourseControllerBase: AbpController
    {
        protected FastCourseControllerBase()
        {
            LocalizationSourceName = FastCourseConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
