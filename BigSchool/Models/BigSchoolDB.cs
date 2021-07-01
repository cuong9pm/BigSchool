using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BigSchool.Models
{
    public partial class BigSchoolDB : DbContext
    {
        public BigSchoolDB()
            : base("name=BigSchoolDB")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);
        }
    }
}
