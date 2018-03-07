using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace MovieReservationApp.Models
{
    public class Movies
    {
        public string MovieName { get; set; }
        public string TheaterName { get; set; }
        public DateTime ShowTimes { get; set; }
        
    }
    public class MovieDBContext : DbContext
    {
        public DbSet<Movies> Movies { get; set; }
    }
}