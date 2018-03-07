using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
namespace MVCWebApplication.Models
{
    public class StudentInfoModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Branch { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime GraduatedDate { get; set; }
        public decimal OverallPercentage { get; set; }
        public string EmailId { get; set; }
   
    }

    public class StudentInfoDBContext : DbContext
    {
        public DbSet<StudentInfoModel> StudentInformations { get; set; }
    }
}