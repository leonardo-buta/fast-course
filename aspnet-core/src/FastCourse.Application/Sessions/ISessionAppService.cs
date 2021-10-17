using System.Threading.Tasks;
using Abp.Application.Services;
using FastCourse.Sessions.Dto;

namespace FastCourse.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
