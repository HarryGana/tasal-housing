using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;
using TasalHousing.Data.Entities;
using TasalHousing.web.Interfaces;
using TasalHousing.web.Models;

namespace TasalHousing.Web.Controllers
{    
    public class AccountController : Controller
    {
        private readonly IAccountsService _accountsService;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            IAccountsService accountsService,
            SignInManager<ApplicationUser> signInManager)
        {
            _accountsService = accountsService;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("~/");
        }

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid) return View();

            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if(!result.Succeeded)
                {
                    ModelState.AddModelError("", "Login failed, Please check your details");
                    return View();
                }
                return LocalRedirect("~/");

            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
            
        }

        [HttpGet]

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid) return View();
            
            try
            {
                var user = await _accountsService.CreateUserAsync(model);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect("~/");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

       
    }
}