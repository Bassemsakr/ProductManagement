
using MediatR;
using ProductManagement.Application.Products.Dtos;

namespace ProductManagement.Application.Products.Queries.GetAll;
public record GetallProductQuery : IRequest<List<ProductDto>>;
