using AutoMapper;
using Bd.Api.Domain;
using Bd.Api.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.ModelMappers.OrderHistoryMappers
{
    public class OrderHistoryDtoAutoMapperProfile : Profile
    {
        public OrderHistoryDtoAutoMapperProfile()
        {
            CreateMap<OrderHistory, OrderHistoryDto>()
                .ReverseMap();
            CreateMap<OrderItemHistory, OrderItemHistoryDto>().ReverseMap();
        }
    }
}
