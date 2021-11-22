using FastCourse.QuestionAlternatives.Dtos;
using System;
using System.Collections.Generic;

namespace FastCourse.Questions.Dtos
{
    public class CreateQuestionDto
    {
        public int CourseId { get; set; }
        public string QuestionDescription { get; set; }
        public int Value { get; set; }
        public List<CreateQuestionAlternativeDto> QuestionAlternatives { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
