namespace ProductManagement.Application.Products.Dtos;
//public record ProductDto(
//    Guid Id,
//    string Name,
//    decimal PriceValue,
//    string Currency,
//    Guid CategoryId);


public record ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal PriceValue { get; set; }
    public string Currency { get; set; }
    public Guid CategoryId { get; set; }
}
