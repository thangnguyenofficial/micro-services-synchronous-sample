using AutoMapper;
using ThangNguyen.GlobalTicket.EventCatalog.Entities;
using ThangNguyen.GlobalTicket.EventCatalog.Models;

namespace ThangNguyen.GlobalTicket.EventCatalog.Code
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Event, EventDto>().ForMember(d => d.CategoryName, opts => opts.MapFrom(s => s.Category.Name));
        }
    }
}
