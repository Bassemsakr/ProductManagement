
using MediatR;
using ProductManagement.Application.Products.Dtos;

namespace ProductManagement.Application.Products.Queries.GetById;
public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;
