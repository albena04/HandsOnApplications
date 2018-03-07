using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreMVCDemo.Models
{
    public class AAAFamilyDBContext : DbContext
    {
 
        public AAAFamilyDBContext(DbContextOptions<AAAFamilyDBContext> options)
           : base(options)
        { }

        public DbSet<StudentInfo> StudentInfo { get; set; }
    }
    public class StudentInfo
    {
        [Key]
        public System.Guid studentid { get; set; }
        //[display(name = "student name")]
        public string studentname { get; set; }
        public string branchname { get; set; }  
        public DateTime startdate { get; set; }    
        public DateTime graduateddate { get; }
        public float gpapercentage { get; set; }
        public string emailid { get; set; }
    }
}
