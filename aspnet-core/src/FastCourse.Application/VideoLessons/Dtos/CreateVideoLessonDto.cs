namespace FastCourse.VideoLessons.Dtos
{
    public class CreateVideoLessonDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public bool Live { get; set; }
    }
}
