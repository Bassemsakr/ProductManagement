﻿
using AutoMapper;
using MediatR;
using ProductManagement.Application.Categories.Dtos;
using ProductManagement.Domian.Categories.Interface;

namespace ProductManagement.Application.Categories.Queries.GetById;
public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        return _mapper.Map<CategoryDto>(category);
    }
}

