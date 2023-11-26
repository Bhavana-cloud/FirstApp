using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LabDal
{
    public class onestudent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class onecompany{
        [Key]
        public int companyid { get; set; }
        public string companyname { get; set; }
        public onestudent onestudents { get; set; }

    }

    public class toomanycourse
    {
        [Key]
        public int Courseid { get; set; }
        public string Coursename { get; set; }
        public List<onestudent> onestudents { get; set; }


    }

    public class Onecourse
    {
        public string onecourseName { get; set; }
        public int onecourseid { get; set; }
    }

    public class TooManyStudent
    {
        [Key]
        public string studentid { get; set; }
        public List<Onecourse> onecourses { get; set; }
    }

    public class LabContext : DbContext
    {
        public DbSet<onestudent> onestudents { get; set; }
        public DbSet<toomanycourse> toomanycourses { get; set; }
        public DbSet<Onecourse> onecourses {get;set;}
        public DbSet<TooManyStudent> TooManyStudents { get;set;}
        public DbSet<onecompany> onecompanys { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectModels;Database=StudentDb;Trusted_Connection = True");
        }
    }
}