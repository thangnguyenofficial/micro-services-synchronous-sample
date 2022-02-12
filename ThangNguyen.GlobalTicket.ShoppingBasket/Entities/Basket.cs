using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Entities
{
    public class Basket
    {
        public Guid BasketId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public ICollection<BasketLine> BasketLines { get; set; }

        public Basket()
        {
            BasketLines = new List<BasketLine>();
        }
    }
}
