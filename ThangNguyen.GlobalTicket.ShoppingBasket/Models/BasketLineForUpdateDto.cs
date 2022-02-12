using System;
using System.ComponentModel.DataAnnotations;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Models
{
    public class BasketLineForUpdateDto
    {
        [Required]
        public int Quantity { get; set; }
    }
}
