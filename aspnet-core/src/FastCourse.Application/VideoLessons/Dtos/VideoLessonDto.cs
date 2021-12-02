using System;

namespace FastCourse.VideoLessons.Dtos
{
    public class VideoLessonDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Live { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
