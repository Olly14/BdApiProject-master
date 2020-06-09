using AutoMapper;
using Bd.Api.Domain;
using Bd.Web.Api.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.ModelMappers.AdministrationMappers
{
    public class UserClaimDtoAutoMapperProfile : Profile
    {
        public UserClaimDtoAutoMapperProfile()
        {
            CreateMap<UserClaim, UserClaimDto>().ReverseMap();
            CreateMap<UserLogin, UserLoginDto>().ReverseMap();
        }
    }
}
