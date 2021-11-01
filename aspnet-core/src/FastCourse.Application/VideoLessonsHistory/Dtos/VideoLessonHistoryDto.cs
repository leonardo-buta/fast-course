using System;

namespace FastCourse.VideoLessonsHistory.Dtos
{
    public class VideoLessonHistoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public int TotalHours { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Signature { get; set; }
        public bool Active { get; set; }
    }
}
