using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization.Internal;
using ThangNguyen.GlobalTicket.Client.Code.Extensions;
using ThangNguyen.GlobalTicket.Client.Models.Api;

namespace ThangNguyen.GlobalTicket.Client.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly HttpClient _client;

        public EventCatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            var response = await _client.GetAsync("/api/events");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<IEnumerable<Event>> GetEventsByCategory(Guid categoryId)
        {
            var response = await _client.GetAsync($"/api/events?categoryId={categoryId}");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var response = await _client.GetAsync($"/api/events/{id}");
            return await response.ReadContentAs<Event>();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var response = await _client.GetAsync("/api/categories");
            return await response.ReadContentAs<List<Category>>();
        }
    }
}
