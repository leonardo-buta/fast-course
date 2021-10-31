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
            var question = ObjectMapper.Map<CertificateEmission>(input);

            await _certificateRepository.InsertAsync(question);

            return ObjectMapper.Map<CertificateEmissionDto>(question);
        }

        public async Task<PagedResultDto<CertificateEmissionDto>> GetListAsync()
        {
            var questions = await _certificateRepository
                .GetAll()
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            var questionsCount = await _certificateRepository.CountAsync();

            return new PagedResultDto<CertificateEmissionDto>(questionsCount, ObjectMapper.Map<List<CertificateEmissionDto>>(questions));
        }
    }
}
