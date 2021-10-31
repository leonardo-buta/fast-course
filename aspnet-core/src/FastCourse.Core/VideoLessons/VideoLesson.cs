using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using FastCourse.Courses;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastCourse.VideoLessons
{
    [Table("VideoLesson")]
    public class VideoLesson : Entity<int>, ICreationAudited
    {
        public Course Course { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public bool Live { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
