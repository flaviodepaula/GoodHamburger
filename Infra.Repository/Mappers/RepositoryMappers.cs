using AutoMapper;
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
        }
    }
}
