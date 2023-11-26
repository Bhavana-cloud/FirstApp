using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDal
{
    //Domain Classes
    #region inheritance
    public class Parent {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParentKey {  get; set; }
        [Required]
        [StringLength(50)]
        public string Name {  get; set; }   
        public bool IsActive { get; set; }  
    }
    public class child : Parent {
        [NotMapped]
        public int ChildId { get; set; }
        public DateTime BirthDate { get; set; }
        [Range(18,110)]
        public int Age {  get; set; }

    }
    public class child2 : Parent
    {
        public string hobbies { get; set; }
    }
    #endregion inheritance

    #region one2one and one2many
    public class One {
        [Key]
        public int Id { get; set; }
        public string Value {  get; set; }
    }
    public class ToOne {
        [Key]
        public int Id { get; set; }
        public One RelatedToOne {  get; set; }
    }

    public class TooMany1
    {
        [Key]
        public int Id { get; set; }
        public List<One> TooManyOnes { get; set; }
    }
    #endregion one2one and one2many


    public class Many
    {
        [Key]
        public int Id { get; set; }
        public List<TooMany2> TooMany2s { get; set; }
    }
    public class TooMany2
    {
        [Key]
        public int Id{get; set; }
        public List<Many> Manys { get; set; }
    }


    //Mapping Layer
   public class TestContext : DbContext
    {
        public DbSet<Parent> Parents { get; set; }
        public DbSet<child> Children { get; set; }
        public DbSet<child2>Children2 { get; set; }
        public DbSet<One> Ones { get; set; }
        public DbSet<ToOne> ToOnes { get; set; }
        public DbSet<TooMany1> TooMany1s {  get; set; }
        public DbSet<Many> Manys { get; set; }
        public DbSet<TooMany2> TooMany2s { get; set; }
            


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectModels;Database=TestDb;Trusted_Connection = True");
        }
    }
}