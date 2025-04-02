using MediatR;

namespace ProductManagement.Application.Products.Commands.Delete;
public record DeleteProductCommand(Guid Id) : IRequest;

