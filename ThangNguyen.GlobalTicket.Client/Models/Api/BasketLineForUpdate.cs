using System;
using System.ComponentModel.DataAnnotations;

namespace ThangNguyen.GlobalTicket.Client.Models.Api
{
    public class BasketLineForUpdate
    {
        [Required]
        public Guid BasketLineId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
