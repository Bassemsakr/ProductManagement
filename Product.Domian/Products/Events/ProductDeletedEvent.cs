
using ProductManagement.Domian.Common;

namespace ProductManagement.Domain.Products.Events;
public class ProductDeletedEvent : DomainEvent
{
    public Guid ProductId { get; }
    public Guid CategoryId { get; }

    public ProductDeletedEvent(Guid productId, Guid categoryId)
    {
        ProductId = productId;
        CategoryId = categoryId;
    }
}
