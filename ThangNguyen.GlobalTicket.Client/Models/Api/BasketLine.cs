using System;

namespace ThangNguyen.GlobalTicket.Client.Models.Api
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }

        public Guid BasketId { get; set; }

        public Guid EventId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public Event Event { get; set; }
    }
}
