using AutoMapper;
using Bd.Api.Domain;
using Bd.Api.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.ModelMappers.OrderHistoryMappers
{
    public class OrderDtoAutoMapperProfile : Profile
    {
        public OrderDtoAutoMapperProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<OrderProduct, OrderProductDto>().ReverseMap();
        }
    }
}
