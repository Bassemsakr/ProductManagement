namespace ProductManagement.Domain.Products.ValueObjects;

public record Price
{
    public decimal Value { get; init; }
    public string Currency { get; init; } 

    private Price() { } 

    public Price(decimal value, string currency)
    {
        if (value < 0)
            throw new ArgumentException("Price cannot be negative");

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency is required");

        Value = value;
        Currency = currency;
    }
}