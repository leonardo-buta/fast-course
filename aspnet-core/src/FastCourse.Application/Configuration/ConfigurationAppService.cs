using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using FastCourse.Configuration.Dto;

namespace FastCourse.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FastCourseAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
