namespace ErpSystem.Domain.Catalog;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private Category() { }

    public Category(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Category name cannot be null or empty.", nameof(name));
        }

        Id = Guid.NewGuid();
        Name = name;
    }

    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("Category name cannot be null or empty.", nameof(newName));
        }
        Name = newName;
    }
}