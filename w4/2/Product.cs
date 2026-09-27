class Product
{
    private readonly string _name;
    private readonly string _id;
    private readonly decimal _price;
    private readonly int _quantity;

    public Product(
        string name,
        string id,
        decimal price,
        int quantity
    )
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("name cannot be empty", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("ID cannot be empty", nameof(id));
        }

        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(quantity),
                "quantity must be greater than zero"
            );
        }

        if (price <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(price),
                "Price must be greater than zero"
            );
        }

        _name = name.Trim();
        _id = id.Trim();
        _price = price;
        _quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetPackingLabelLine()
    {
        return $"{_name} — {_id}";
    }
}
