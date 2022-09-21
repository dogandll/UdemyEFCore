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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FluentAPI
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
            #endregion
            #region Delete Behaviors Database
            //Cascade -> Categori silinir ise bağlı olan tüm ürünler silinir.
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);

            ////Restrict -> Categori silinir ise bağlı olan tüm ürünler silinmez ! İlk önce ürünler silinir sonra bağlı kategori
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);

            ////SetNull -> Categori silinir ise bağlı olan tüm ürünlerin categori alanına null atanır !
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.SetNull);

            //////NoAction -> Hiçbirşey yapma ben database tarafında ayarlıyacağım !
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
            #endregion
            #region DatabaseGenerated Attribute
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).HasComputedColumnSql("[Price]*[Kdv]");
            //DataAno olarak vermek yerine fluent API olarakda ayarlayabiliriz.
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedOnAdd(); //identity
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedOnAddOrUpdate(); //computed
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedNever(); //none
            #endregion
        }


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
