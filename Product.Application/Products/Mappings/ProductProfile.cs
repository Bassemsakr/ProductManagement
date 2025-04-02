
using AutoMapper;
using ProductManagement.Application.Products.Dtos;
using ProductManagement.Domain.Products.Entities;

namespace Assessment.Application.Products.Mappings;
public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.PriceValue, opt => opt.MapFrom(src => src.Price.Value))
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Price.Currency));

        //CreateMap<Product, ProductDto>()
        //    .ConstructUsing(src => new ProductDto(
        //        src.Id, // Map Id
        //        src.Name, // Map Name
        //        src.Price.Value, // Map PriceValue
        //        src.Price.Currency, // Map Currency
        //        src.CategoryId // Map CategoryId
        //    ));

    }
}
