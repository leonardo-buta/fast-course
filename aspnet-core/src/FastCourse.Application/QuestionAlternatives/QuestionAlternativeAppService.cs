using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using FastCourse.QuestionAlternatives.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCourse.QuestionAlternatives
{
    public class QuestionAppService : FastCourseAppServiceBase, IQuestionAppService
    {
        private readonly IRepository<QuestionAlternative> _questionAlternativeRepository;

        public QuestionAppService(IRepository<QuestionAlternative> questionAlternativeRepository)
        {
            _questionAlternativeRepository = questionAlternativeRepository;
        }

        public async Task<QuestionAlternativeDto> CreateAsync(QuestionAlternativeDto input)
        {
            var alternative = ObjectMapper.Map<QuestionAlternative>(input);

            await _questionAlternativeRepository.InsertAsync(alternative);

            return ObjectMapper.Map<QuestionAlternativeDto>(alternative);
        }

        public async Task<PagedResultDto<QuestionAlternativeDto>> GetListAsync()
        {
            var alternatives = await _questionAlternativeRepository
                .GetAll()
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            var alternativesCount = await _questionAlternativeRepository.CountAsync();

            return new PagedResultDto<QuestionAlternativeDto>(alternativesCount, ObjectMapper.Map<List<QuestionAlternativeDto>>(alternatives));
        }
    }
}
