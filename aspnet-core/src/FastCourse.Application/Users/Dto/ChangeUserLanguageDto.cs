using System.ComponentModel.DataAnnotations;

namespace FastCourse.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}