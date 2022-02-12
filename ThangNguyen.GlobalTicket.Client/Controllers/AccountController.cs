using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ThangNguyen.GlobalTicket.Client.Models;
using ThangNguyen.GlobalTicket.Client.Models.AccountViewModels;

namespace ThangNguyen.GlobalTicket.Client.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> RegisterAsync()
        {
            return await Task.Run(View);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = new ApplicationUser
            {
                UserName = registerViewModel.Email,
                Email = registerViewModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                const bool isPersistent = true;
                await _signInManager.SignInAsync(user, isPersistent);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(registerViewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> LoginAsync()
        {
            return await Task.Run(View);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View();

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "The account is locked out");
                return View();
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }
        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
