using System;
using System.ComponentModel.DataAnnotations;

namespace ThangNguyen.GlobalTicket.Client.Models.Api
{
    public class BasketLineForCreation
    {
        [Required]
        public Guid EventId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
