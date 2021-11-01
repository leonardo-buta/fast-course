using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using FastCourse.CertificateEmissions.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCourse.CertificateEmissions
{
    public class CertificateEmissionAppService : FastCourseAppServiceBase, ICertificateEmissionAppService
    {
        private readonly IRepository<CertificateEmission> _certificateRepository;

        public CertificateEmissionAppService(IRepository<CertificateEmission> certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<CertificateEmissionDto> CreateAsync(CreateCertificateEmissionDto input)
        {
            var certificate = ObjectMapper.Map<CertificateEmission>(input);

            await _certificateRepository.InsertAsync(certificate);

            return ObjectMapper.Map<CertificateEmissionDto>(certificate);
        }

        public async Task<PagedResultDto<CertificateEmissionDto>> GetListAsync()
        {
            var certificates = await _certificateRepository
                .GetAll()
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            var certificatesCount = await _certificateRepository.CountAsync();

            return new PagedResultDto<CertificateEmissionDto>(certificatesCount, ObjectMapper.Map<List<CertificateEmissionDto>>(certificates));
        }
    }
}
