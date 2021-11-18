using System;

namespace FastCourse.VideoLessonsUserProgress.Dtos
{
    public class VideoLessonUserProgressDto
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
