namespace FastCourse.QuestionAlternatives.Dtos
{
    public class CreateQuestionAlternativeDto
    {
        public int QuestionId { get; set; }
        public string AlternativeDescription { get; set; }
        public bool IsCorrect { get; set; }
    }
}
