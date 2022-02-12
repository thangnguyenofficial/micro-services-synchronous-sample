using System;
using System.Threading.Tasks;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure.Repositories
{
    public interface IBasketRepository
    {
        Task<Basket> GetAsyncBasketById(Guid basketId);

        void AddBasket(Basket basket);

        Task<bool> SaveChanges();

        Task<bool> CheckBasketExists(Guid basketId);
    }
}
