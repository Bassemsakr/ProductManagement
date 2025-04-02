using ProductManagement.Domain.Common;
using ProductManagement.Domain.Products.Events;
using ProductManagement.Domain.Products.ValueObjects;
using ProductManagement.Domian.Common;

namespace ProductManagement.Domain.Products.Entities;

public class Product : Entity<Guid>
{
    public string Name { get; private set; }
    public Price Price { get; private set; }
    public Guid CategoryId { get; private set; }

    private Product() { } 

    public Product(Guid id, string name, Price price, Guid categoryId)
    {
        Id = id;
        Name = name;
        Price = price;
        CategoryId = categoryId;

        AddDomainEvent(new ProductCreatedEvent(Id, CategoryId));
    }

    public void Update(string name, Price price, Guid categoryId)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;

        AddDomainEvent(new ProductUpdatedEvent(this, categoryId));
    }

    public void DeleteWithdecresecatagorie()
    {
        AddDomainEvent(new ProductDeletedEvent(Id, CategoryId));
    }

}

