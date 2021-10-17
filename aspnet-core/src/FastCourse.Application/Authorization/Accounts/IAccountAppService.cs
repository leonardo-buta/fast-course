using System.Threading.Tasks;
using Abp.Application.Services;
using FastCourse.Authorization.Accounts.Dto;

namespace FastCourse.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
