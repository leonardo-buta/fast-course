using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using FastCourse.Certificates.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCourse.Certificates
{
    public class CertificateAppService : FastCourseAppServiceBase, ICertificateAppService
    {
        private readonly IRepository<Certificate> _certificateRepository;

        public CertificateAppService(IRepository<Certificate> certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<CertificateDto> CreateAsync(CreateCertificateDto input)
        {
            var certificate = ObjectMapper.Map<Certificate>(input);
            certificate.Active = true;

            await _certificateRepository.InsertAsync(certificate);

            return ObjectMapper.Map<CertificateDto>(certificate);
        }

        public async Task<PagedResultDto<CertificateDto>> GetListAsync()
        {
            var certificates = await _certificateRepository
                .GetAllIncluding(x => x.Course)
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            var certificatesCount = await _certificateRepository.CountAsync();

            return new PagedResultDto<CertificateDto>(certificatesCount, ObjectMapper.Map<List<CertificateDto>>(certificates));
        }
    }
}
