using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using FastCourse.Authorization.Users;
using FastCourse.Certificates;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastCourse.CertificateEmissions
{
    [Table("CertificateEmission")]
    public class CertificateEmission : Entity<int>, IHasCreationTime
    {
        public Certificate Certificate { get; set; }
        public User User { get; set; }
        public DateTime EmissionDate { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
