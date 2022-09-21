using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

DbContextInitializer.Build();

using (var _context = new AppDbContext())
{
    #region List
    //    var product = await _context.Products.ToListAsync();

    //    product.ForEach(p =>
    //    {

    //        //var state = _context.Entry(p).State;

    //        //Console.WriteLine($"{p.Id} :{p.Name} - {p.Price} - {p.Stock} - state: {state}");
    //    });
    //}
    #endregion
    #region Create
    //var newProduct = new Product { Name = "Kalem200", Price = 200, Stock = 100, Barcode = 333 };

    //Console.WriteLine($"ilk state : {_context.Entry(newProduct).State} ");

    //await _context.AddAsync(newProduct);

    //Console.WriteLine($"son state : {_context.Entry(newProduct).State} ");

    //await _context.SaveChangesAsync();

    //Console.WriteLine($"save state : {_context.Entry(newProduct).State} ");
    #endregion
    #region Update
    //var product = await _context.Products.FirstAsync();
    //Console.WriteLine($"ilk state : {_context.Entry(product).State} ");
    //product.Stock = 1000;
    //Console.WriteLine($"ikinci state : {_context.Entry(product).State} ");
    //await _context.SaveChangesAsync();
    //Console.WriteLine($"savechanges state : {_context.Entry(product).State} ");


    #endregion
    #region Delete
    //var product = await _context.Products.FirstAsync();
    //Console.WriteLine($"ilk state : {_context.Entry(product).State} ");
    //_context.Remove(product);
    ////_context.Entry(product).State = EntityState.Deleted;
    //Console.WriteLine($"ikinci state : {_context.Entry(product).State} ");
    //await _context.SaveChangesAsync();
    //Console.WriteLine($"savechanges state : {_context.Entry(product).State} ");
    #endregion
    #region ChangeTracker

    //_context.Products.Add(new Product { Name = "Kalem13", Price = 200, Stock = 100, Barcode = 123 });
    //_context.Products.Add(new Product { Name = "Kalem14", Price = 200, Stock = 100, Barcode = 123 });
    //_context.Products.Add(new Product { Name = "Kalem15", Price = 200, Stock = 100, Barcode = 123 });

    //_context.SaveChanges();
    //Savechange metot appcontext ezilerek chagetracker kullanıldı.


    //var product = _context.Products.AsNoTracking().ToList();

    //product.ForEach(p => { Console.WriteLine($"{p.Id} :{p.Name} -{p.Stock}"); });



    #endregion
    #region LinqMetot
    ////Eğer 1 numaralı data yoksa geriye hata döner
    //var product = _context.Products.First(x => x.Id == 1);
    ////Eğer 1 numaralı data yoksa geriye null
    //var product1 = _context.Products.FirstOrDefault(x => x.Id == 1);
    ////Tek 1 data döner , birden fazla data olur ise hata döner
    //var product2 = await _context.Products.SingleAsync(x => x.Id == 1);
    ////Şartı sağlayan listesyi döner
    //var product3 =await _context.Products.Where(x => x.Id == 1 && x.Name == "kalem10" || x.Stock > 1).ToListAsync();
    #endregion
    #region NavigationInsert
    #region Simple1
    //var category = new Category() { Name = "Kalemler" };

    //var product = new Product { Name = "Kalem 1", Price = 100, Stock = 200, Barcode = 123, Category = category };
    //_context.Products.Add(product);
    #endregion
    #region Simple2

    //var category = _context.Categories.First(x => x.Name == "Defterler");
    //var product = new Product { Name = "Defter 3", Price = 100, Stock = 100, Barcode = 123, CategoryId = category.Id };
    //_context.Add(product);
    //_context.SaveChanges();
    //Console.WriteLine("Veritabanına kayıt edildi");
    #endregion
    #region Simple3
    //Product - > Parent  | ProductFeature ->Childed

    //var product = new Product() { Name = "Silgi1", Price = 200, Stock = 200, Barcode = 123, CategoryId = 2, ProductFeature = new ProductFeature { Color = "red", Height = 100, Width = 200 } };
    //_context.Products.Add(product);
    //_context.SaveChanges();
    #endregion
    #region Simple4
    //var student = new Student { Name = "Uğur", Age = 23 };
    //student.Teachers.Add(new() { Name = "Şevki Öğretmen" });
    //student.Teachers.Add(new() { Name = "Naim Öğretmen" });
    //_context.Add(student);

    //var teacher = new Teacher() { Name = "Halil" };
    //teacher.Students.Add(new Student() { Name = "Doğan", Age = 31 });
    //_context.Add(teacher);

    //var teacher = new Teacher() { Name = "Mehmet Öğretmen", Students = new List<Student>() { new Student { Name = "Fatma", Age = 35 }, new Student { Name = "Zehra", Age = 22 } } };
    //_context.Add(teacher);

    //var teacher = _context.Teachers.First(z => z.Name == "Halil Öğretmen");

    //teacher.Students.Add(new Student { Name = "Baran", Age = 26 });
    #endregion
    #endregion
    #region DeleteBehaviors

    //Cascade -> Categori silinir ise bağlı olan tüm ürünler silinir.
    //var category = new Category
    //{
    //    Name = "Kalemler",
    //    Products = new List<Product> {
    //    new () { Name = "Kalem 1", Price = 200, Stock = 200, Barcode = 123 },
    //    new() { Name = "Kalem 2", Price = 300, Stock =300, Barcode = 123 },
    //    new() { Name = "Kalem 3", Price = 400, Stock = 400, Barcode = 123 }
    //    }
    //};
    //_context.Add(category);


    ////Restrict -> Categori silinir ise bağlı olan tüm ürünler silinmez ! İlk önce ürünler silinir sonra bağlı kategori
    //var category = _context.Categories.First();
    //var products = _context.Products.Where(x => x.CategoryId == category.Id).ToList();
    //_context.RemoveRange(products);
    //_context.Remove(category);

    //SetNull -> Categori silinir ise bağlı olan tüm ürünler null olarak setlenir !
    //var category = new Category
    //{
    //    Name = "Kalemler",
    //    Products = new List<Product> {
    //   new () { Name = "Kalem 1", Price = 200, Stock = 200, Barcode = 123 },
    //   new() { Name = "Kalem 2", Price = 300, Stock =300, Barcode = 123 },
    //   new() { Name = "Kalem 3", Price = 400, Stock = 400, Barcode = 123 }
    //   }
    //};
    //_context.Add(category);

    //var category = _context.Categories.First();
    //_context.Remove(category);
    //#endregion


    //_context.SaveChanges();
    //Console.WriteLine("Veritabanına kayıt edildi.");
    #endregion
    #region DatabaseGenerated Attributed
    _context.Products.Add(new() { Name = "Kalem 1", Price = 100, Stock = 200, Barcode = 123, Kdv = 18 });
    _context.SaveChanges();
    Console.WriteLine("Eklendi");
    #endregion
}

