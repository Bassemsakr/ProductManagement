
using MediatR;
using ProductManagement.Application.Categories.Dtos;

namespace ProductManagement.Application.Categories.Queries.GetById;
public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDto>;
