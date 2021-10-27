using System;

namespace FastCourse.Courses.Dtos
{
    public class CreateCourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PreRequisites { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
    }
}
