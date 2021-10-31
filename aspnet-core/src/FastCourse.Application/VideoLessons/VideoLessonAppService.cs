using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using FastCourse.VideoLessons.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCourse.VideoLessons
{
    public class VideoLessonAppService : FastCourseAppServiceBase, IVideoLessonAppService
    {
        private readonly IRepository<VideoLesson> _videoLessonRepository;

        public VideoLessonAppService(IRepository<VideoLesson> videoLessonRepository)
        {
            _videoLessonRepository = videoLessonRepository;
        }

        public async Task<VideoLessonDto> CreateAsync(CreateVideoLessonDto input)
        {
            var question = ObjectMapper.Map<VideoLesson>(input);
            question.Active = true;

            await _videoLessonRepository.InsertAsync(question);

            return ObjectMapper.Map<VideoLessonDto>(question);
        }

        public async Task<PagedResultDto<VideoLessonDto>> GetListAsync()
        {
            var questions = await _videoLessonRepository
                .GetAll()
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            var questionsCount = await _videoLessonRepository.CountAsync();

            return new PagedResultDto<VideoLessonDto>(questionsCount, ObjectMapper.Map<List<VideoLessonDto>>(questions));
        }
    }
}
