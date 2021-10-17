using Abp.Application.Services;
using FastCourse.MultiTenancy.Dto;

namespace FastCourse.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

