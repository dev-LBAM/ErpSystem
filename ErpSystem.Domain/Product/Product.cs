using ErpSystem.Domain.Catalog;
using ErpSystem.Domain.Product.Lots;

namespace ErpSystem.Domain.Product;

public class Product
{
    public Guid Id { get; private set; }
    public string Sku { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public bool IsActive { get; private set; }
    public Brand? Brand { get; set; }
    public Category? Category { get; set; }
    public List<Lot> Lots { get; set; } = new List<Lot>();
    private Product() { }

    public Product(string sku, string name, string description, decimal price, Guid brandId, Guid categoryId)
    {
        if (string.IsNullOrWhiteSpace(sku))
        {
            throw new ArgumentException("SKU cannot be null or empty.", nameof(sku));
        }
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description cannot be null or empty.", nameof(description));
        }
        if (price <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
        }
        if (brandId == Guid.Empty)
        {
            throw new ArgumentException("Brand ID cannot be empty.", nameof(brandId));
        }
        if (categoryId == Guid.Empty)
        {
            throw new ArgumentException("Category ID cannot be empty.", nameof(categoryId));
        }

        Id = Guid.NewGuid();
        Sku = sku;
        Name = name;
        Description = description;
        Price = price;
        BrandId = brandId;
        CategoryId = categoryId;
        IsActive = true;
    }

    public void UpdateDetails(string name, string description, Guid brandId, Guid categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }
        if (brandId == Guid.Empty)
        {
            throw new ArgumentException("Brand ID cannot be empty.", nameof(brandId));
        }
        if (categoryId == Guid.Empty)
        {
            throw new ArgumentException("Category ID cannot be empty.", nameof(categoryId));
        }
        Name = name;
        Description = description;
        BrandId = brandId;
        CategoryId = categoryId;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(newPrice), "Price cannot be negative.");
        }
        Price = newPrice;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}