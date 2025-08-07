using System.Threading.Tasks;
using System.Collections.Generic;

namespace ErpSystem.Domain.Catalog;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id);
    Task<List<Category>> ListAllAsync();
    Task<Category> AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Category category);
}