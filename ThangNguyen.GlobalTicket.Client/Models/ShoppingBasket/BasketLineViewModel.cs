using System;

namespace ThangNguyen.GlobalTicket.Client.Models.ShoppingBasket
{
    public class BasketLineViewModel
    {
        public Guid BasketLineId { get; set; }

        public Guid EventId { get; set; }

        public string EventName { get; set; }

        public DateTimeOffset Date { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
