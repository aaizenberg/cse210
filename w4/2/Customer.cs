class Customer
{
    private readonly string _name;
    private readonly Address _address;

    public Customer(
        string name,
        Address address
    )
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty", nameof(name));
        }

        ArgumentNullException.ThrowIfNull(address);

        _address = address;
        _name = name.Trim();
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetShippingLabelLine()
    {
        return $"{_name}\n{_address.GetFullAddress()}";
    }
}
