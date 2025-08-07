namespace ErpSystem.Domain.Catalog;

public class Brand
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private Brand()
    {
        Id = Guid.Empty;
        Name = string.Empty;
    }

    public Brand(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Brand name cannot be null or empty.", nameof(name));
        }

        Id = Guid.NewGuid();
        Name = name;
    }

    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("Brand name cannot be null or empty.", nameof(newName));
        }
        Name = newName;
    }
}