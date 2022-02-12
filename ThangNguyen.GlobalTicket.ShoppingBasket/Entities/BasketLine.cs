using System;
using System.ComponentModel.DataAnnotations;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Entities
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }

        public Guid EventId { get; set; }

        public Event Event { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Guid BasketId { get; set; }

        public Basket Basket { get; set; }
    }
}
