using System.Threading.Tasks;
using System.Collections.Generic;

namespace ErpSystem.Domain.Catalog;

public interface IBrandRepository
{
    Task<Brand?> GetByIdAsync(Guid id);
    Task<List<Brand>> ListAllAsync();
    Task<Brand> AddAsync(Brand brand);
    Task UpdateAsync(Brand brand);
    Task DeleteAsync(Brand brand);
}