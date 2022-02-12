using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure.Repositories
{
    public class BasketLineRepository : IBasketLineRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public BasketLineRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
        }

        public async Task<IEnumerable<BasketLine>> GetBasketLines(Guid basketId)
        {
            return await _shoppingBasketDbContext.BasketLines.Include(bl => bl.Event)
                .Where(b => b.BasketId == basketId).ToListAsync();
        }

        public Task<BasketLine> GetBasketLineById(Guid basketLineId)
        {
            return _shoppingBasketDbContext.BasketLines.Include(bl => bl.Event)
                .FirstOrDefaultAsync(bl => bl.BasketLineId == basketLineId);
        }

        public async Task<BasketLine> AddOrUpdateBasketLine(Guid basketId, BasketLine basketLine)
        {
            var existingLine = await _shoppingBasketDbContext.BasketLines.Include(bl => bl.Event)
                .Where(b => b.BasketId == basketId && b.EventId == basketLine.EventId).FirstOrDefaultAsync();
            if (existingLine == null)
            {
                basketLine.BasketId = basketId;
                _shoppingBasketDbContext.BasketLines.Add(basketLine);
                return basketLine;
            }
            existingLine.Quantity += basketLine.Quantity;
            return existingLine;
        }

        public void UpdateBasketLine(BasketLine basketLine)
        {
            _shoppingBasketDbContext.BasketLines.Update(basketLine);
        }

        public void RemoveBasketLine(BasketLine basketLine)
        {
            _shoppingBasketDbContext.BasketLines.Remove(basketLine);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _shoppingBasketDbContext.SaveChangesAsync() > 0);
        }
    }
}
