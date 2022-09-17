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
}

