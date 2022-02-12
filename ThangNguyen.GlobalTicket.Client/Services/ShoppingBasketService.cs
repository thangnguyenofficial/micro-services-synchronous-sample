using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ThangNguyen.GlobalTicket.Client.Code.Extensions;
using ThangNguyen.GlobalTicket.Client.Models.Api;

namespace ThangNguyen.GlobalTicket.Client.Services
{
    public class ShoppingBasketService : IShoppingBasketService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingBasketService(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Basket> GetBasket(Guid basketId)
        {
            if (basketId == Guid.Empty)
                return null;
            var response = await _client.GetAsync($"/api/baskets/{basketId}");
            return await response.ReadContentAs<Basket>();
        }

        public async Task<BasketLine> AddToBasket(Guid basketId, BasketLineForCreation basketLine)
        {
            if (basketId == Guid.Empty)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var basketResponse = await _client.PostAsJson("/api/baskets", new BasketForCreation { UserId = Guid.Parse(userId) });
                var basket = await basketResponse.ReadContentAs<Basket>();
                basketId = basket.BasketId;
            }

            var response = await _client.PostAsJson($"api/baskets/{basketId}/basketlines", basketLine);
            return await response.ReadContentAs<BasketLine>();
        }

        public async Task<IEnumerable<BasketLine>> GetLinesForBasket(Guid basketId)
        {
            if (basketId == Guid.Empty)
                return Array.Empty<BasketLine>();
            var response = await _client.GetAsync($"/api/baskets/{basketId}/basketLines");
            return await response.ReadContentAs<BasketLine[]>();
        }

        public async Task UpdateProductLine(Guid basketId, BasketLineForUpdate basketLineForUpdate)
        {
            await _client.PutAsJson($"/api/baskets/{basketId}/basketLines/{basketLineForUpdate.BasketLineId}", basketLineForUpdate);
        }

        public async Task RemoveProductLine(Guid basketId, Guid basketLineId)
        {
            await _client.DeleteAsync($"/api/baskets/{basketId}/basketLines/{basketLineId}");
        }
    }
}
