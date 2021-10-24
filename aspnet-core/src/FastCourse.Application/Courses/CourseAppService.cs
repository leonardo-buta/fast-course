using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using FastCourse.Courses.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCourse.Courses
{
    public class CourseAppService : FastCourseAppServiceBase, ICourseAppService
    {
        private readonly IRepository<Course, int> _courseRepository;

        public CourseAppService(IRepository<Course, int> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<PagedResultDto<CourseDto>> GetListAsync()
        {
            var courses = await _courseRepository
                .GetAll()
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            var coursesCount = await _courseRepository.CountAsync();

            return new PagedResultDto<CourseDto>(coursesCount, ObjectMapper.Map<List<CourseDto>>(courses));
        }
    }
}
