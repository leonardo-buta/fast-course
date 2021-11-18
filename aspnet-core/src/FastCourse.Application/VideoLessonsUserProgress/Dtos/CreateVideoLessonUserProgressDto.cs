using System;

namespace FastCourse.VideoLessonsUserProgress.Dtos
{
    public class CreateVideoLessonUserProgressDto
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
        public int TotalHours { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Signature { get; set; }
        public bool Active { get; set; }
    }
}
