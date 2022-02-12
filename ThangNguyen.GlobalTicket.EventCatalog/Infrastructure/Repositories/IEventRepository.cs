using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThangNguyen.GlobalTicket.EventCatalog.Entities;

namespace ThangNguyen.GlobalTicket.EventCatalog.Infrastructure.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEventsByCategory(Guid categoryId);

        Task<Event> GetEvent(Guid eventId);
    }
}
