using Abp.Domain.Entities;
using FastCourse.Authorization.Users;
using FastCourse.VideoLessons;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastCourse.VideoLessonsUserProgress
{
    [Table("VideoLessonUserProgress")]
    public class VideoLessonUserProgress : Entity<int>
    {
        public VideoLesson VideoLesson { get; set; }
        public User User { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
