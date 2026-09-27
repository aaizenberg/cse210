class Order
{
    private readonly Customer _customer;
    private readonly List<Product> _products = new();

    public Order(
        Customer customer
    )
    {
        ArgumentNullException.ThrowIfNull(customer);
        _customer = customer;
    }

    public void AddProduct(
        Product product
    )
    {
        ArgumentNullException.ThrowIfNull(product);
        _products.Add(product);
    }


    public decimal CalculateTotalCost()
    {
        decimal total = 0m;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        total += _customer.IsInUSA() ? 5m : 30m;

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "";

        foreach (Product product in _products)
        {
            label += product.GetPackingLabelLine() + "\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabelLine();
    }
}
