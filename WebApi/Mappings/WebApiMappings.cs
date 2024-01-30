using AutoMapper;
using Domain.Orders.Models;
using Domain.Products.Models;
using WebApi.Models;

namespace WebApi.Mappings
{
    public class WebApiMappings : Profile
    {
        public WebApiMappings() {

            CreateMap<RequestProductViewModel, OrderDTO>()
                .ForMember(dest => dest.Products, opt=> opt.MapFrom(src => src.Products));

            CreateMap<RequestProduct, Product>();

            CreateMap<UpdateProductViewModel, OrderDTO>()
                .ForMember(dest => dest.Id, opt=> opt.MapFrom(src=> src.Id))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        }
    }
}
