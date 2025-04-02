using Microsoft.EntityFrameworkCore;
using ProductManagement.Domian.Categories.Entity;
using ProductManagement.Domian.Categories.Interface;
using ProductManagement.Infrastructure.Context;

namespace ProductManagement.Infrastructure.Repositories;

public class CategoryRepository (ApplicationDbContext _context): ICategoryRepository
{
    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }
    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Category category)
    {

        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}
