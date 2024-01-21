using AutoMapper;
using Domain.Models.Order;
using Domain.Models.Products;
using Infra.Repository.Entities;

namespace Domain.Mapping
{
    public class DomainMapping : Profile
    {
        public DomainMapping() {

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
            CreateMap<OrderDTO, Order>();


            CreateMap<CreateOrderCommand, ProductDTO>()
            .ForMember(dest => dest, opt => opt.MapFrom(src => src.Products));

            CreateMap<ProductDTO, CreateOrderCommand>()
                .ForMember(dest => dest.Products, 
                           opt => opt.MapFrom( src => new List<Product>
                                                      { new(src.Description,
                                                            src.Value.Value,
                                                            (ProductCategory)Enum.Parse(typeof(ProductCategory), src.Category))
                                                      }));
        }
    }
}
