using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public BasketRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
        }

        public async Task<Basket> GetAsyncBasketById(Guid basketId)
        {
            return await _shoppingBasketDbContext.Baskets.Include(sb => sb.BasketLines)
                .FirstOrDefaultAsync(b => b.BasketId == basketId);
        }

        public void AddBasket(Basket basket)
        {
            _shoppingBasketDbContext.Baskets.Add(basket);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _shoppingBasketDbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> CheckBasketExists(Guid basketId)
        {
            return await _shoppingBasketDbContext.Baskets.AnyAsync(b => b.BasketId == basketId);
        }
    }
}
