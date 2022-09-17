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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextInitializer.Build();
            optionsBuilder.UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));
        }

        #region FluentAPI
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Product>().HasKey(x => x.Id);
        //}
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
