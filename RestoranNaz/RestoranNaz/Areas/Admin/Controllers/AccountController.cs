using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerBI.Api.Models;
using RestoranNaz.ViewModel;

namespace RestoranNaz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Create(AdminLoginVM adminLoginVM)
        {
            AppUser user = new AppUser()
            {
                FullName=adminLoginVM.UserName,      
            };
            await _userManager.CreateAsync(user,"Admin123@");
            return View(user);
        }
    }
}
