
using AutoMapper;
using MediatR;
using ProductManagement.Application.Products.Dtos;
using ProductManagement.Domain.Products.Interfaces;

namespace ProductManagement.Application.Products.Queries.GetAll;

public class GetAllProductQueryHandler : IRequestHandler<GetallProductQuery, List<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetallProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<List<ProductDto>>(products);
    }

}
