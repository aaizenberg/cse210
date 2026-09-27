class Address
{
    private readonly string _street;
    private readonly string _city;
    private readonly string _province;
    private readonly string _country;

    public Address(
       string street,
       string city,
       string province,
       string country
    )
    {
        if (string.IsNullOrWhiteSpace(street))
        {
            throw new ArgumentException("Street cannot be empty", nameof(street));
        }

        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException("City cannot be empty", nameof(city));
        }

        if (string.IsNullOrWhiteSpace(province))
        {
            throw new ArgumentException("Province cannot be empty", nameof(province));
        }

        if (string.IsNullOrWhiteSpace(country))
        {
            throw new ArgumentException("Country cannot be empty", nameof(country));
        }

        _street = street.Trim();
        _city = city.Trim();
        _province = province.Trim();
        _country = country.Trim();
    }

    public bool IsInUSA()
    {
        return string.Equals(_country, "USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_province}\n{_country}";
    }
}
