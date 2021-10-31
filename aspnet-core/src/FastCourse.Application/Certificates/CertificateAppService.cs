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
            var question = ObjectMapper.Map<Certificate>(input);
            question.Active = true;

            await _certificateRepository.InsertAsync(question);

            return ObjectMapper.Map<CertificateDto>(question);
        }

        public async Task<PagedResultDto<CertificateDto>> GetListAsync()
        {
            var questions = await _certificateRepository
                .GetAll()
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            var questionsCount = await _certificateRepository.CountAsync();

            return new PagedResultDto<CertificateDto>(questionsCount, ObjectMapper.Map<List<CertificateDto>>(questions));
        }
    }
}
