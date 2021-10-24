using AutoMapper;
using FastCourse.Courses;
using FastCourse.Courses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCourse.Mappings
{
    public class CourseMapProfile : Profile
    {
        public CourseMapProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<Course, CreateCourseInput>();
        }
    }
}
