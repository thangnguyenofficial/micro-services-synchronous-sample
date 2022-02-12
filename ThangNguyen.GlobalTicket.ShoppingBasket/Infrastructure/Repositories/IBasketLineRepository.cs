using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure.Repositories
{
    public interface IBasketLineRepository
    {
        Task<IEnumerable<BasketLine>> GetBasketLines(Guid basketId);

        Task<BasketLine> GetBasketLineById(Guid basketLineId);

        Task<BasketLine> AddOrUpdateBasketLine(Guid basketId, BasketLine basketLine);

        void UpdateBasketLine(BasketLine basketLine);

        void RemoveBasketLine(BasketLine basketLine);

        Task<bool> SaveChanges();
    }
}
