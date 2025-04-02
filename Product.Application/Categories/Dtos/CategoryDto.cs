namespace ProductManagement.Application.Categories.Dtos;
public record CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int ProductCount { get; set; }
}
