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
            CreateMap<OrderDTO, Order>();

        }
    }
}
