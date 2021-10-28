using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using FastCourse.Questions;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastCourse.QuestionAlternatives
{
    [Table("QuestionAlternative")]
    public class QuestionAlternative : Entity<int>, ICreationAudited
    {
        public Question Question { get; set; }
        public string AlternativeDescription { get; set; }
        public bool IsCorrect { get; set; }
        public bool Active { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
