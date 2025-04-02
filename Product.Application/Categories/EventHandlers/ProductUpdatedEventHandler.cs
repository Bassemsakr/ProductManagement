
using MediatR;
using ProductManagement.Domain.Products.Events;
using ProductManagement.Domian.Categories.Interface;

namespace Assessment.Application.Categories.EventHandlers;
public class ProductUpdatedEventHandler : INotificationHandler<ProductUpdatedEvent>
{
    private readonly ICategoryRepository _categoryRepository;

    public ProductUpdatedEventHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(ProductUpdatedEvent notification, CancellationToken cancellationToken)
    {
        if (notification.OldCategoryId != notification.Product.CategoryId)
        {
            // Decrement old category
            var oldCategory = await _categoryRepository.GetByIdAsync(notification.OldCategoryId);
            if (oldCategory != null)
            {
                oldCategory.DecrementProductCount();
                await _categoryRepository.UpdateAsync(oldCategory);
            }

            // Increment new category
            var newCategory = await _categoryRepository.GetByIdAsync(notification.Product.CategoryId);
            if (newCategory != null)
            {
                newCategory.IncrementProductCount();
                await _categoryRepository.UpdateAsync(newCategory);
            }
        }
    }
}