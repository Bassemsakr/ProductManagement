
using MediatR;
using ProductManagement.Domian.Categories.Entity;
using ProductManagement.Domian.Categories.Interface;

namespace ProductManagement.Application.Categories.Commands.Create;
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(Guid.NewGuid(), request.Name);
        await _categoryRepository.AddAsync(category);
        return category.Id;
    }
}
