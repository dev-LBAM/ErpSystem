namespace ErpSystem.Domain.Product.Lots;

public class Lot
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; set; }
    public int StockQuantity { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public bool IsActive { get; private set; }
    public Product? Product { get; set; }

    private Lot() { }

    public Lot(Guid productId, int stockQuantity, DateTime expirationDate)
    {
        if (productId == Guid.Empty)
        {
            throw new ArgumentException("Product ID cannot be empty.", nameof(productId));
        }
        if (stockQuantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(stockQuantity), "Stock quantity must be greater than zero.");
        }
        if (expirationDate <= DateTime.Today)
        {
            throw new ArgumentOutOfRangeException(nameof(expirationDate), "Expiration date must be in the future.");
        }

        Id = Guid.NewGuid();
        ProductId = productId;
        StockQuantity = stockQuantity;
        ExpirationDate = expirationDate;
        IsActive = true;
    }

    public void UpdateStock(int stockAdjustment)
    {
        if (StockQuantity + stockAdjustment < 0)
        {
            throw new InvalidOperationException("Cannot reduce stock below zero.");
        }
        StockQuantity += stockAdjustment;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}