
using MediatR;
using ProductManagement.Domain.Products.Events;
using ProductManagement.Domian.Categories.Interface;

namespace ProductManagement.Application.Categories.EventHandlers;
public class ProductDeletedEventHandler : INotificationHandler<ProductDeletedEvent>
{
    private readonly ICategoryRepository _categoryRepository;

    public ProductDeletedEventHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(ProductDeletedEvent notification, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(notification.CategoryId);
        if (category != null)
        {
            category.DecrementProductCount();
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
