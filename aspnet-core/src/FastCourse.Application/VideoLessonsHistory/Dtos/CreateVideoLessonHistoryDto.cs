using System;

namespace FastCourse.VideoLessonsHistory.Dtos
{
    public class CreateVideoLessonHistoryDto
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
        public int TotalHours { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Signature { get; set; }
        public bool Active { get; set; }
    }
}
