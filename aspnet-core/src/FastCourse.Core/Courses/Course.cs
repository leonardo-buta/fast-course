using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastCourse.Courses
{
    [Table("Course")]
    public class Course : Entity<int>, ICreationAudited
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PreRequisites { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
