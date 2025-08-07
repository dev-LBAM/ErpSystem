using ErpSystem.Domain.Catalog;
using ErpSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ErpSystem.Infrastructure.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly ApplicationDbContext _context;

    public BrandRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Brand> AddAsync(Brand brand)
    {
        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();
        return brand;
    }

    public async Task<Brand?> GetByIdAsync(Guid id)
    {
        return await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<Brand>> ListAllAsync()
    {
        return await _context.Brands.ToListAsync();
    }

    public async Task UpdateAsync(Brand brand)
    {
        _context.Entry(brand).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Brand brand)
    {
        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync();
    }
}