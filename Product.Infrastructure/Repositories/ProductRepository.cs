using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Products.Entities;
using ProductManagement.Domain.Products.Interfaces;
using ProductManagement.Infrastructure.Context;

namespace ProductManagement.Infrastructure.Repositories;
public class ProductRepository(ApplicationDbContext _context) : IProductRepository
{

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products.Include(p => p.Price).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}