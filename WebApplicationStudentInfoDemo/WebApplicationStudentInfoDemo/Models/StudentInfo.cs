using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationStudentInfoDemo.Models
{
    public class StudentInfoDBContext : DbContext
    {
        public StudentInfoDBContext(DbContextOptions<StudentInfoDBContext> options)
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
        public DateTime GraduatedDate { get; set; }
        public Double OverallPercentage { get; set; }
        public string EmailId { get; set; }
    }
}
