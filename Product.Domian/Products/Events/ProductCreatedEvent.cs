
using ProductManagement.Domian.Common;

namespace ProductManagement.Domain.Products.Events;
public class ProductCreatedEvent : DomainEvent
{
    public Guid ProductId { get; }
    public Guid CategoryId { get; }

    public ProductCreatedEvent(Guid productId, Guid categoryId)
    {
        ProductId = productId;
        CategoryId = categoryId;
    }
}
