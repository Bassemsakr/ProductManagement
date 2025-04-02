
using MediatR;
using ProductManagement.Application.Categories.Commands.Delete;
using ProductManagement.Domain.Common.Exceptions;
using ProductManagement.Domian.Categories.Entity;
using ProductManagement.Domian.Categories.Interface;

namespace Assessment.Application.Categories.Commands.Delete;
public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category == null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        await _categoryRepository.DeleteAsync(category);
    }
}