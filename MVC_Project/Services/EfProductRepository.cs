using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;

namespace MVC_Project.Services;

public sealed class EfProductRepository(AppDbContext db) : IProductRepository
{
    public IReadOnlyList<Product> GetAll() =>
        db.Products.AsNoTracking().OrderBy(p => p.Id).ToList();

    public Product? GetById(int id) =>
        db.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);

    public void Update(Product product)
    {
        db.Products.Update(product);
        db.SaveChanges();
    }

    public bool Delete(int id)
    {
        var entity = db.Products.Find(id);
        if (entity is null)
            return false;
        db.Products.Remove(entity);
        db.SaveChanges();
        return true;
    }
}
