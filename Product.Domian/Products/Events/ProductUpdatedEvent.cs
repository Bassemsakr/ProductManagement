
using ProductManagement.Domain.Products.Entities;
using ProductManagement.Domian.Common;

namespace ProductManagement.Domain.Products.Events;

public class ProductUpdatedEvent : DomainEvent
{
    public Product Product { get; }
    public Guid OldCategoryId { get; }  
    public DateTime UpdatedAt { get; } = DateTime.UtcNow;

    public ProductUpdatedEvent(Product product, Guid oldCategoryId)
    {
        Product = product;
        OldCategoryId = oldCategoryId;  
    }

}
