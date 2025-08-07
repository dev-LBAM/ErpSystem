using ErpSystem.Domain.Product;
using System.Threading.Tasks;

namespace ErpSystem.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Create(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            await _productRepository.AddAsync(product);
        }
    }
}