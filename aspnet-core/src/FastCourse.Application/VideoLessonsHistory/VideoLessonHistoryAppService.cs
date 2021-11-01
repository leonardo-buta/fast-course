using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using FastCourse.VideoLessonsHistory.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastCourse.VideoLessonsHistory
{
    public class VideoLessonHistoryAppService : FastCourseAppServiceBase, IVideoLessonHistoryAppService
    {
        private readonly IRepository<VideoLessonHistory> _certificateRepository;

        public VideoLessonHistoryAppService(IRepository<VideoLessonHistory> certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<VideoLessonHistoryDto> CreateAsync(CreateVideoLessonHistoryDto input)
        {
            var videoLesson = ObjectMapper.Map<VideoLessonHistory>(input);

            await _certificateRepository.InsertAsync(videoLesson);

            return ObjectMapper.Map<VideoLessonHistoryDto>(videoLesson);
        }

        public async Task<PagedResultDto<VideoLessonHistoryDto>> GetListAsync()
        {
            var videoLessons = await _certificateRepository
                .GetAll()
                .ToListAsync();

            var videoLessonsCount = await _certificateRepository.CountAsync();

            return new PagedResultDto<VideoLessonHistoryDto>(videoLessonsCount, ObjectMapper.Map<List<VideoLessonHistoryDto>>(videoLessons));
        }
    }
}
