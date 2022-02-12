using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ThangNguyen.GlobalTicket.Client.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string CardNumber { get; set; }

        public string SecurityNumber { get; set; }

        [RegularExpression(@"(0[1-9]|1[0-2])\/[0-9]{2}", ErrorMessage = "Expiration should match a valid MM/YY value")]
        public string Expiration { get; set; }

        public string CardHolderName { get; set; }

        public int CardType { get; set; }
    }
}
