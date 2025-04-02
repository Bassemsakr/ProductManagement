using MediatR;

namespace ProductManagement.Application.Products.Commands.Update;
public record UpdateProductCommand(
    Guid Id,
    string Name,
    decimal PriceValue,
    string Currency,
    Guid CategoryId) : IRequest;
