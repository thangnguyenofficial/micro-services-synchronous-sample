using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThangNguyen.GlobalTicket.EventCatalog.Entities;

namespace ThangNguyen.GlobalTicket.EventCatalog.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public EventRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }

        public async Task<IEnumerable<Event>> GetEventsByCategory(Guid categoryId)
        {
            return await _eventCatalogDbContext.Events
                .Include(e => e.Category)
                .Where(e => e.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<Event> GetEvent(Guid eventId)
        {
            return await _eventCatalogDbContext.Events
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.EventId == eventId);
        }
    }
}
