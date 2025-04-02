
using ProductManagement.Domain.Products.Entities;

namespace ProductManagement.Domain.Products.Interfaces;
public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);

}
