using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using FastCourse.Courses;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastCourse.Certificates
{
    [Table("Certificate")]
    public class Certificate : Entity<int>, IHasCreationTime
    {
        public string Name { get; set; }
        public Course Course { get; set; }
        public int TotalHours { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Signature { get; set; }
        public bool Active { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
