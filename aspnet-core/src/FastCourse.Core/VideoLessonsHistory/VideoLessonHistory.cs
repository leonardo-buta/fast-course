using Abp.Domain.Entities;
using FastCourse.VideoLessons;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastCourse.VideoLessonsHistory
{
    [Table("VideoLessonHistory")]
    public class VideoLessonHistory : Entity<int>
    {
        public VideoLesson VideoLesson { get; set; }
        public long UserId { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
