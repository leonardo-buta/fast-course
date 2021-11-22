using AutoMapper;
using FastCourse.Authorization.Users;
using FastCourse.Courses;
using FastCourse.Courses.Dtos;
using FastCourse.QuestionAlternatives;
using FastCourse.QuestionAlternatives.Dtos;
using FastCourse.Questions;
using FastCourse.Questions.Dtos;
using FastCourse.Users.Dto;

namespace FastCourse.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            // User
            CreateMap<UserDto, User>();
            CreateMap<UserDto, User>()
                .ForMember(x => x.Roles, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore());

            CreateMap<CreateUserDto, User>();
            CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

            // Course
            CreateMap<Course, CourseDto>();
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<Course, CourseSelectDto>();

            // Question
            CreateMap<CreateQuestionDto, Question>();
            CreateMap<QuestionDto, Question>().ReverseMap();

            // Question Alternative
            CreateMap<CreateQuestionAlternativeDto, QuestionAlternative>();
        }
    }
}
