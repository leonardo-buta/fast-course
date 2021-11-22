using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using FastCourse.Courses;
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
        private readonly IRepository<Course> _courseRepository;

        public QuestionAppService(IRepository<Question> questionRepository, IRepository<Course> courseRepository)
        {
            _questionRepository = questionRepository;
            _courseRepository = courseRepository;
        }

        public async Task<QuestionDto> CreateAsync(CreateQuestionDto input)
        {
            var question = ObjectMapper.Map<Question>(input);
            question.Course = await _courseRepository.GetAsync(input.CourseId);
            question.Active = true;

            await _questionRepository.InsertAsync(question);

            return ObjectMapper.Map<QuestionDto>(question);
        }

        public async Task<PagedResultDto<QuestionDto>> GetListAsync()
        {
            var questions = await _questionRepository
                .GetAllIncluding(x => x.Course)
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            var questionsCount = await _questionRepository.CountAsync();

            return new PagedResultDto<QuestionDto>(questionsCount, ObjectMapper.Map<List<QuestionDto>>(questions));
        }
    }
}
