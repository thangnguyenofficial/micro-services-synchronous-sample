using System;
using System.Threading.Tasks;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Services
{
    public interface IEventCatalogService
    {
        Task<Event> GetEvent(Guid id);
    }
}
