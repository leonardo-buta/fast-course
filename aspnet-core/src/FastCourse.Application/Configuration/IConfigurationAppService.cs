using System.Threading.Tasks;
using FastCourse.Configuration.Dto;

namespace FastCourse.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
