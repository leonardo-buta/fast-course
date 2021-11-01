using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using FastCourse.Authorization.Users;
using FastCourse.Courses;
using FastCourse.QuestionAlternatives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastCourse.Questions
{
    [Table("Question")]
    public class Question : Entity<int>, IHasCreationTime
    {
        public Course Course { get; set; }
        public string QuestionDescription { get; set; }
        public int Value { get; set; }
        public bool Active { get; set; }
        public List<QuestionAlternative> QuestionAlternatives { get; set; }
        public User User { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
