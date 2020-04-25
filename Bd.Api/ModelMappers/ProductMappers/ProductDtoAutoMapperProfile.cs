using AutoMapper;
using Bd.Api.Domain;
using Bd.Api.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.ModelMappers.ProductMappers
{
    public class ProductDtoAutoMapperProfile : Profile
    {
        public ProductDtoAutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
