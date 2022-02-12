using AutoMapper;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;
using ThangNguyen.GlobalTicket.ShoppingBasket.Models;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Code
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Basket, BasketDto>();
            CreateMap<BasketForCreationDto, Basket>();
            CreateMap<BasketLineForCreationDto, BasketLine>();
            CreateMap<BasketLineForUpdateDto, BasketLine>();
        }
    }
}
