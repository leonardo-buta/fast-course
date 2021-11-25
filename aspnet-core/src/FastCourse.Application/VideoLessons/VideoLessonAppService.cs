using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using FastCourse.Courses;
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
        private readonly IRepository<Course> _courseRepository;

        public VideoLessonAppService(IRepository<VideoLesson> videoLessonRepository, IRepository<Course> courseRepository)
        {
            _videoLessonRepository = videoLessonRepository;
            _courseRepository = courseRepository;
        }

        public async Task<VideoLessonDto> CreateAsync(CreateVideoLessonDto input)
        {
            var videoLesson = ObjectMapper.Map<VideoLesson>(input);
            videoLesson.Course = await _courseRepository.GetAsync(input.CourseId);
            videoLesson.Active = true;

            await _videoLessonRepository.InsertAsync(videoLesson);

            return ObjectMapper.Map<VideoLessonDto>(videoLesson);
        }

        public async Task<PagedResultDto<VideoLessonDto>> GetListAsync()
        {
            var videoLessons = await _videoLessonRepository
                .GetAllIncluding(x => x.Course)
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            var videoLessonsCount = await _videoLessonRepository.CountAsync();

            return new PagedResultDto<VideoLessonDto>(videoLessonsCount, ObjectMapper.Map<List<VideoLessonDto>>(videoLessons));
        }
    }
}
