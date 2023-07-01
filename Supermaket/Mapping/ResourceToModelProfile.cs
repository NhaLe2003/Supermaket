
using AutoMapper;
using Supermaket.Domain.Models;
using Supermaket.Resources;


namespace Supermaket.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile() 
        { 
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<ProductResource, Product>();
        }
    }
}
