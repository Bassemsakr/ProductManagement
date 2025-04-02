
using AutoMapper;
using ProductManagement.Application.Categories.Dtos;
using ProductManagement.Domian.Categories.Entity;

namespace AssesProductManagementsment.Application.Categories.Mappings;
public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>();
    }
}
