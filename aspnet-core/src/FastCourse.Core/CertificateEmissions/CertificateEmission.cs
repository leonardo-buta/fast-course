using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastCourse.CertificateEmissions
{
    [Table("CertificateEmission")]
    public class CertificateEmission : Entity<int>, ICreationAudited
    {
        public int CertificateId { get; set; }
        public int UserId { get; set; }
        public DateTime EmissionDate { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
