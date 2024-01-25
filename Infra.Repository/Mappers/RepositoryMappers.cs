using AutoMapper;
using Domain.Models.Order;
using Domain.Models.Products;

namespace Infra.Repository.Mappers
{
    public class RepositoryMappers : Profile
    {
        public RepositoryMappers()
        {
            CreateMap<Entities.Products, Product>()
                .ForMember(dest=> dest.Id, opt=> opt.MapFrom(src => src.ProductId))
                .ForMember(dest=> dest.Description, opt=> opt.MapFrom(src => src.Description))
                .ForMember(dest=> dest.Category, opt=> opt.MapFrom(src=> Enum.Parse<enumProductCategory>(src.Category)))
                .ForMember(dest=> dest.CategoryType, opt=> opt.MapFrom(src=> Enum.Parse<enumProductCategoryType>(src.CategoryType)))
                .ForMember(dest=> dest.Value, opt=> opt.MapFrom(src => src.Value));

            CreateMap<Entities.Orders, OrderDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductsOnOrder.Select(x=> x.Product)));

        }
    }
}
