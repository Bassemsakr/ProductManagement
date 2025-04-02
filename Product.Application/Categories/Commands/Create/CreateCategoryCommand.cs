using MediatR;

namespace ProductManagement.Application.Categories.Commands.Create;
public record CreateCategoryCommand(string Name) : IRequest<Guid>;
