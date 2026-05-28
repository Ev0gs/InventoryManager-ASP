using MVC_Project.Models;

namespace MVC_Project.Services;

public interface IProductRepository
{
    IReadOnlyList<Product> GetAll();
    Product? GetById(int id);
    void Update(Product product);
    bool Delete(int id);
}
