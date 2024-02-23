using AutoMapper;
using Domain.Customers.DTOs;
using Domain.Orders.Models;
using Domain.Products.Enums;
using Domain.Products.Models;
using Infra.Repository.Entities;

namespace Infra.Repository.Mappers
{
    public class RepositoryMappers : Profile
    {
        public RepositoryMappers()
        {
            CreateMap<Entities.Products, Product>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => Enum.Parse<enumProductCategory>(src.Category)))
                .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => Enum.Parse<enumProductCategoryType>(src.CategoryType)))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));


            CreateMap<Entities.Orders, OrderDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.TotalAmount));

            CreateMap<Product, Entities.Products>();


            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));

            CreateMap<Address, AddressDTO>();



            //Domain.Customers.Customer => Entities.Customer

            CreateMap<Domain.Customers.Customer, Entities.Customer>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Actived));

            CreateMap<Domain.Customers.Address, Entities.Address>();
        }
    }
}
