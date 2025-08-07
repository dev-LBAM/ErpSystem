using ErpSystem.Domain.Product;
using ErpSystem.Domain.Product.Lots;
using ErpSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpSystem.Infrastructure.Repositories;

public class LotRepository : ILotRepository
{
    private readonly ApplicationDbContext _context;

    public LotRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Lot> AddAsync(Lot lot)
    {
        await _context.Lots.AddAsync(lot);
        await _context.SaveChangesAsync();
        return lot;
    }

    public async Task DeleteAsync(Lot lot)
    {
        _context.Lots.Remove(lot);
        await _context.SaveChangesAsync();
    }

    public async Task<Lot?> GetByIdAsync(Guid id)
    {
        return await _context.Lots
            .Include(l => l.Product)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<List<Lot>> ListByProductIdAsync(Guid productId)
    {
        return await _context.Lots
            .Where(l => l.ProductId == productId)
            .Include(l => l.Product)
            .ToListAsync();
    }

    public async Task UpdateAsync(Lot lot)
    {
        _context.Entry(lot).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}