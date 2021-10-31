using System;

namespace FastCourse.CertificateEmissions.Dtos
{
    public class CreateCertificateEmissionDto
    {
        public int CertificateId { get; set; }
        public int UserId { get; set; }
        public DateTime EmissionDate { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
