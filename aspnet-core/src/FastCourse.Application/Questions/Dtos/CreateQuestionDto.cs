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
        public bool Active { get; set; }
        public long? CreatorUserId { get; set; }
        public List<QuestionAlternativeDto> QuestionAlternatives { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
