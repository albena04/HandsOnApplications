using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace WebApWebAPIDemo.Models
{
    public class StudentInfoContext: DbContext
    {
        public StudentInfoContext(DbContextOptions<StudentInfoContext> options)
           : base(options)
        {
        }

        public DbSet<StudentInfo> StudentInfomations { get; set; }
    }
    public class StudentInfo
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Branch { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime GraduatedDate{ get; set; }
        public Double OverallPercentage { get; set; }
        public string EmailId { get; set; }

    }
}
