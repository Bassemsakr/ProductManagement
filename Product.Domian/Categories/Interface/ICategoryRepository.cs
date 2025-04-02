﻿using ProductManagement.Domian.Categories.Entity;

namespace ProductManagement.Domian.Categories.Interface;
public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid id);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Category category);

}
