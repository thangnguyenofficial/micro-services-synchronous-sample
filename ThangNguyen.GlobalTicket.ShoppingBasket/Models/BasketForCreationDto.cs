using System;
using System.ComponentModel.DataAnnotations;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Models
{
    public class BasketForCreationDto
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
