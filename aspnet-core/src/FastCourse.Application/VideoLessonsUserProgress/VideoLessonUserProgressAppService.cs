using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using FastCourse.VideoLessonsUserProgress;
using FastCourse.VideoLessonsUserProgress.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastCourse.VideoLessonsHistory
{
    public class VideoLessonUserProgressAppService : FastCourseAppServiceBase, IVideoLessonUserProgressAppService
    {
        private readonly IRepository<VideoLessonUserProgress> _certificateRepository;

        public VideoLessonUserProgressAppService(IRepository<VideoLessonUserProgress> certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<VideoLessonUserProgressDto> CreateAsync(CreateVideoLessonUserProgressDto input)
        {
            var videoLesson = ObjectMapper.Map<VideoLessonUserProgress>(input);

            await _certificateRepository.InsertAsync(videoLesson);

            return ObjectMapper.Map<VideoLessonUserProgressDto>(videoLesson);
        }

        public async Task<PagedResultDto<VideoLessonUserProgressDto>> GetListAsync()
        {
            var videoLessons = await _certificateRepository
                .GetAll()
                .ToListAsync();

            var videoLessonsCount = await _certificateRepository.CountAsync();

            return new PagedResultDto<VideoLessonUserProgressDto>(videoLessonsCount, ObjectMapper.Map<List<VideoLessonUserProgressDto>>(videoLessons));
        }
    }
}
