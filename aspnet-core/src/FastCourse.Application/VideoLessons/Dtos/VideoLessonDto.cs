namespace FastCourse.VideoLessons.Dtos
{
    public class VideoLessonDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public bool Live { get; set; }
    }
}
