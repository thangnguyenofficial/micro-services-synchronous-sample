using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ThangNguyen.GlobalTicket.Client.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}
