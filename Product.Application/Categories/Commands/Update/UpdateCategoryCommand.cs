using MediatR;

namespace ProductManagement.Application.Categories.Commands.Update;
public record UpdateCategoryCommand(
    Guid Id,
    string Name) : IRequest;
