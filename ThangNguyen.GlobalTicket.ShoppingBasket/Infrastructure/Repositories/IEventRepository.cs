using System;
using System.Threading.Tasks;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure.Repositories
{
    public interface IEventRepository
    {
        Task<bool> CheckEventExists(Guid eventId);

        void AddEvent(Event theEvent);

        Task<bool> SaveChanges();
    }
}
