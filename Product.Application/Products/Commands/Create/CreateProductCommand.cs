using MediatR;

namespace ProductManagement.Application.Products.Commands.Create;
public record CreateProductCommand(
    string Name,
    decimal PriceValue,
    string Currency,
    Guid CategoryId) : IRequest<Guid>;
