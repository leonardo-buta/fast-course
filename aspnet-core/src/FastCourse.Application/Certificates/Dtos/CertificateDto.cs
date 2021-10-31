using System;

namespace FastCourse.Certificates.Dtos
{
    public class CertificateDto
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
