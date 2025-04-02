using ProductManagement.Domain.Products.Entities;
using ProductManagement.Domain.Products.Interfaces;
using MediatR;
using ProductManagement.Application.Products.Commands.Create;
using ProductManagement.Domain.Products.ValueObjects;

namespace Assessment.Application.Products.Commands.Create;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var product = new Product(
                Guid.NewGuid(),
                request.Name,
                new Price(request.PriceValue, request.Currency),
                request.CategoryId);

            await _productRepository.AddAsync(product);
            return product.Id;

        }
        catch (Exception ex)
        {
            throw;
        }
    }
}