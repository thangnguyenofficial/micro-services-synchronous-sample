using AutoMapper;
using ThangNguyen.GlobalTicket.Client.Models.Api;
using ThangNguyen.GlobalTicket.Client.Models.ShoppingBasket;

namespace ThangNguyen.GlobalTicket.Client.Code
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BasketLine, BasketLineViewModel>().ForMember(d => d.Date, opts => opts.MapFrom(s => s.Event.Date));
        }
    }
}
