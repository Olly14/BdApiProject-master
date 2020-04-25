using AutoMapper;
using Bd.Api.Domain;
using Bd.Api.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.ModelMappers.DropDownListsMappers
{
    public class DropDownListsDtoAutoMapperProfile : Profile
    {
        public DropDownListsDtoAutoMapperProfile()
        {
            CreateMap<Gender, GenderDto>().ReverseMap();
        }
    }
}
