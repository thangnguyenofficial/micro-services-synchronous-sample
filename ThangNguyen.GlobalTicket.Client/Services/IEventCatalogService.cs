using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThangNguyen.GlobalTicket.Client.Models.Api;

namespace ThangNguyen.GlobalTicket.Client.Services
{
    public interface IEventCatalogService
    {
        Task<IEnumerable<Event>> GetEvents();

        Task<IEnumerable<Event>> GetEventsByCategory(Guid categoryId);

        Task<Event> GetEvent(Guid id);

        Task<IEnumerable<Category>> GetCategories();
    }
}