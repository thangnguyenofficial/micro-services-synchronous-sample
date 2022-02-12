using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public EventRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
        }

        public async Task<bool> CheckEventExists(Guid eventId)
        {
            return await _shoppingBasketDbContext.Events.AnyAsync(e => e.EventId == eventId);
        }

        public void AddEvent(Event theEvent)
        {
            _shoppingBasketDbContext.Events.Add(theEvent);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _shoppingBasketDbContext.SaveChangesAsync() > 0);
        }
    }
}
