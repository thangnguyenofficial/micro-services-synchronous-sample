using System;
using System.Net.Http;
using System.Threading.Tasks;
using ThangNguyen.GlobalTicket.ShoppingBasket.Code.Extensions;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly HttpClient _client;

        public EventCatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var response = await _client.GetAsync($"/api/events/{id}");
            return await response.ReadContentAs<Event>();
        }
    }
}
