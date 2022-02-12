using System;
using System.ComponentModel.DataAnnotations;

namespace ThangNguyen.GlobalTicket.Client.Models.Api
{
    public class BasketForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
