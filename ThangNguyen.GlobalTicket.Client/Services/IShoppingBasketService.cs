using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThangNguyen.GlobalTicket.Client.Models.Api;

namespace ThangNguyen.GlobalTicket.Client.Services
{
    public interface IShoppingBasketService
    {
        Task<Basket> GetBasket(Guid basketId);
        
        Task<BasketLine> AddToBasket(Guid basketId, BasketLineForCreation basketLine);

        Task<IEnumerable<BasketLine>> GetLinesForBasket(Guid basketId);

        Task UpdateProductLine(Guid basketId, BasketLineForUpdate basketLineForUpdate);

        Task RemoveProductLine(Guid basketId, Guid basketLineId);
    }
}
