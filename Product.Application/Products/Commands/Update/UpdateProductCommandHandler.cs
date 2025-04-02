
using MediatR;
using ProductManagement.Application.Products.Commands.Update;
using ProductManagement.Domain.Common.Exceptions;
using ProductManagement.Domain.Products.Entities;
using ProductManagement.Domain.Products.Interfaces;
using ProductManagement.Domain.Products.ValueObjects;

namespace Assessment.Application.Products.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        product.Update(
            request.Name,
            new Price(request.PriceValue, request.Currency),
            request.CategoryId);

        await _productRepository.UpdateAsync(product);
    }
}