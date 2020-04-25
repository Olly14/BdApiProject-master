using AutoMapper;
using Bd.Api.Domain;
using Bd.Api.DtoModels;
using Microsoft.AspNetCore.Identity;

namespace Bd.Api.ModelMappers.AppUserMappers
{
    public class AppUserDtoAutoMapperProfile : Profile
    {
        public AppUserDtoAutoMapperProfile()
        {
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            //CreateMap<RegistrationViewModel, AppUserViewModel>().ReverseMap();
            //CreateMap<RegistrationViewModel, AppUser>().ReverseMap();
            //CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
        }

    }
}
