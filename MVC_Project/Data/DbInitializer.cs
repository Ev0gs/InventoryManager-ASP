using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace MVC_Project.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(AppDbContext db, CancellationToken cancellationToken = default)
    {
        if (await db.Products.AnyAsync(cancellationToken))
            return;

        db.Products.AddRange(
            new Product { Name = "Product A", Description = "Premier article", Price = 10.99 },
            new Product { Name = "Product B", Description = "Deuxième article", Price = 19.99 },
            new Product { Name = "Product C", Description = "Troisième article", Price = 5.99 });

        await db.SaveChangesAsync(cancellationToken);
    }
}
