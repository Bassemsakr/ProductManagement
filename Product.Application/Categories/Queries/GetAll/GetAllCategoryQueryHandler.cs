
using AutoMapper;
using MediatR;
using ProductManagement.Application.Categories.Dtos;
using ProductManagement.Domian.Categories.Interface;
using System.Collections.Generic;

namespace ProductManagement.Application.Categories.Queries.GetAll;
public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAllAsync();
        return _mapper.Map<List<CategoryDto>>(category);
    }
}

