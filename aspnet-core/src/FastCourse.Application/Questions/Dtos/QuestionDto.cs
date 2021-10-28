using System;

namespace FastCourse.Questions.Dtos
{
    public class QuestionDto
    {
        public string CourseName { get; set; }
        public string QuestionDescription { get; set; }
        public int Value { get; set; }
        public bool Active { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
