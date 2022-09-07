using Microsoft.EntityFrameworkCore;
using UdemyEFCore.DatabaseFirst.DAL;

DbContextInitializer.Build();

using (var _context = new AppDbContext(DbContextInitializer.optionsBuilder.Options))
{
    var products = await _context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id}  :{p.Name}");
    });
}