
using MediatR;
using ProductManagement.Domain.Products.Events;
using ProductManagement.Domian.Categories.Interface;

namespace ProductManagement.Application.Categories.EventHandlers;
public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
{
    private readonly ICategoryRepository _categoryRepository;

    public ProductCreatedEventHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(ProductCreatedEvent notification, CancellationToken ct)
    {
        var category = await _categoryRepository.GetByIdAsync(notification.CategoryId);
        if (category != null)
        {
            category.IncrementProductCount();
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
