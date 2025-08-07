using ErpSystem.Domain.Product.Lots;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpSystem.Domain.Product;

public interface ILotRepository
{
    Task<Lot?> GetByIdAsync(Guid id);
    Task<Lot> AddAsync(Lot lot);
    Task UpdateAsync(Lot lot);
    Task DeleteAsync(Lot lot);
    Task<List<Lot>> ListByProductIdAsync(Guid productId);
}