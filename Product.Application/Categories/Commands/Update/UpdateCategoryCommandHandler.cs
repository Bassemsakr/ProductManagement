
using MediatR;
using ProductManagement.Domain.Common.Exceptions;
using ProductManagement.Domian.Categories.Entity;
using ProductManagement.Domian.Categories.Interface;

namespace ProductManagement.Application.Categories.Commands.Update;
public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category == null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        category.UpdateName(request.Name);
        await _categoryRepository.UpdateAsync(category);
    }
}