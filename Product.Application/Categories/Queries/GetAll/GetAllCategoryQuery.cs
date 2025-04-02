
using MediatR;
using ProductManagement.Application.Categories.Dtos;

namespace ProductManagement.Application.Categories.Queries.GetAll;
public record GetAllCategoryQuery : IRequest<List<CategoryDto>>;
