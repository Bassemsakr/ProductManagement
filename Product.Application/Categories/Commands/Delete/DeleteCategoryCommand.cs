using MediatR;

namespace ProductManagement.Application.Categories.Commands.Delete;
public record DeleteCategoryCommand(Guid Id) : IRequest;
