using AutoMapper;
using Supermaket.Domain.Models;
using Supermaket.Resources;

namespace Supermaket.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile() 
        {
            CreateMap<Category, CategoryResource>();
        }
    }
}
