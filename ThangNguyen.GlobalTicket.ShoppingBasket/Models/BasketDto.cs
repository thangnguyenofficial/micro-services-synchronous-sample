using System;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Models
{
    public class BasketDto
    {
        public Guid BasketId { get; set; }

        public Guid UserId { get; set; }

        public int NumberOfItems { get; set; }
    }
}
