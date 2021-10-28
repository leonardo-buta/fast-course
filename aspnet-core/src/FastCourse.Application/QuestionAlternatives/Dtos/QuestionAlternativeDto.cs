namespace FastCourse.QuestionAlternatives.Dtos
{
    public class QuestionAlternativeDto
    {
        public string QuestionDescription { get; set; }
        public string AlternativeDescription { get; set; }
        public bool IsCorrect { get; set; }
        public bool Active { get; set; }
    }
}
