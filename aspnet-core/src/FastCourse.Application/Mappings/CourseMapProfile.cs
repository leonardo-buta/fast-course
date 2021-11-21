using AutoMapper;
using FastCourse.Courses;
using FastCourse.Courses.Dtos;

namespace FastCourse.Mappings
{
    public class CourseMapProfile : Profile
    {
        public CourseMapProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<Course, CreateCourseDto>().ReverseMap();
        }
    }
}
