using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using FastCourse.Questions.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCourse.Questions
{
    public class QuestionAppService : FastCourseAppServiceBase, IQuestionAppService
    {
        private readonly IRepository<Question> _questionRepository;

        public QuestionAppService(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<QuestionDto> CreateAsync(CreateQuestionDto input)
        {
            var question = ObjectMapper.Map<Question>(input);
            question.Active = true;

            await _questionRepository.InsertAsync(question);

            return ObjectMapper.Map<QuestionDto>(question);
        }

        public async Task<PagedResultDto<QuestionDto>> GetListAsync()
        {
            var questions = await _questionRepository
                .GetAll()
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            var questionsCount = await _questionRepository.CountAsync();

            return new PagedResultDto<QuestionDto>(questionsCount, ObjectMapper.Map<List<QuestionDto>>(questions));
        }
    }
}
