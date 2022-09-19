using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextInitializer.Build();
            optionsBuilder.UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));
        }

        #region FluentAPI

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //One to Many

            //    modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.Category_Id);

            //One to One

            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);

            //Many to Many

            //modelBuilder.Entity<Student>()
            //    .HasMany(x => x.Teachers)
            //    .WithMany(x => x.Students)
            //    .UsingEntity<Dictionary<string, object>>(
            //    "StudentTeacherManyToMany",
            //    x => x.HasOne<Teacher>().WithMany().HasForeignKey("TeacherId").HasConstraintName("FK_TeacherId"),
            //       x => x.HasOne<Student>().WithMany().HasForeignKey("StudentId").HasConstraintName("FK_StudentId")
            //    );

        }
 
        #endregion
        //public override int SaveChanges()
        //{
        //    //Track edilen tüm datalara ulaşma
        //    ChangeTracker.Entries().ToList().ForEach(e =>
        //    {
        //        //Track edilen datalar içinde product türünde olanları yakalama
        //        if (e.Entity is Product p)
        //        {
        //            if (e.State == EntityState.Added)
        //            {
        //                p.CreateDate = DateTime.Now;
        //            }
        //        }
        //    });
        //    return base.SaveChanges();
        //}

    }

}
