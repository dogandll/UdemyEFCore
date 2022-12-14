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
        public DbSet<ProductFeature> productFeatures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        //TPH(Table-Per-Hierachy)

        //Base class dbset edildiği zaman  miras alan tabloları birlştirmektedir.
        //Aşağıdaki durumda persons tablosu oluşturup Discriminator sutünu oluşturarak manager ve employees ayrımını sağlamaktadır.

        //public DbSet<BasePerson> Persons { get; set; }

        //Base tablo dbset edilmediği zaman ortak olan özellikler ile miras alan sınıflar için ayrı tablo oluşturmaktadır.

        //TPT (Table - Per - Type)

        // AppDbcontext altında onmodelcreating metot çağıralarak set edilecek sıınıflar için tablo ismi verilmektedir.
        //Her miras alan tablo için içerisinde bulunan property'e göre tablo sutün oluşturmaktadır.
        //Base class da ise ortak olanları birleştirerek tek tablo yapmaktadır.
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<ProductFull> ProductFulls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextInitializer.Build();
            //LazyLoading ve Console Log Kapatıldı
            //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseLazyLoadingProxies().UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));
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
            #region TBT(Table - Per - Type)
            //modelBuilder.Entity<BasePerson>().ToTable("Persons");
            //modelBuilder.Entity<Employee>().ToTable("Employees");
            //modelBuilder.Entity<Manager>().ToTable("Managers");
            #endregion
            #region OwnedEntityType
            //Inheritance sınıflar için miras alma yerine navigation property gibi child sınıfları tanımladıktan sonra lat taraftaki tanım gerçekleşerek db yansıması gerçekleşmektedir.
            //modelBuilder.Entity<Manager>().OwnsOne(x => x.Person);
            #endregion
            #region KeylessEntity
            //SQL sorgusunu EFCORE üzerinde kullanmak için oluşturulan sorgunun birebir aynı entity oluşturulur.
            //ProductFull entity oluşturulduktan sonra [Keyless] attribute kullanılmaz ise aşagidaki fluentAPI komutu kullanılır.
            modelBuilder.Entity<ProductFull>().HasNoKey();
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
