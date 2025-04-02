
using MediatR;
using ProductManagement.Application.Products.Commands.Delete;
using ProductManagement.Domain.Common.Exceptions;
using ProductManagement.Domain.Products.Entities;
using ProductManagement.Domain.Products.Interfaces;

namespace Assessment.Application.Products.Commands.Delete;
public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }
        product.DeleteWithdecresecatagorie();
        await _productRepository.DeleteAsync(product);
    }
}
