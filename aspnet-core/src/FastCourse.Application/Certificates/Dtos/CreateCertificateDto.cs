using System;

namespace FastCourse.Certificates.Dtos
{
    public class CreateCertificateDto
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
        public int TotalHours { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Signature { get; set; }
        public bool Active { get; set; }
    }
}
