using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

DbContextInitializer.Build();

using (var _context = new AppDbContext())
{
    var product = await _context.Products.ToListAsync();

    product.ForEach(p => { Console.WriteLine($"{p.Id} :{p.Name} - {p.Price} - {p.Stock}"); });
}