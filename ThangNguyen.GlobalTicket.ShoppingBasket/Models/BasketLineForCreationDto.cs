using System;
using System.ComponentModel.DataAnnotations;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Models
{
    public class BasketLineForCreationDto
    {
        [Required]
        public Guid EventId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
