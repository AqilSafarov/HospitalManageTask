using HospitalMangeTask.Models;
using HospitalMangeTask.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMangeTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(AppDbContext context, UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(VmRegistor model)
        {
            if (ModelState.IsValid)
            {
                var appUser = new AppUser() { Name = model.Name, Surname = model.Surname, Email = model.Email, UserName = model.Email };
                var result = await _userManager.CreateAsync(appUser, model.Password);

                #region Succed
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, "Admin");

                    await _signInManager.SignInAsync(appUser, false);

                    return RedirectToAction("Index", "Doctor");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }
                #endregion

            }
            return View(model);

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(VmLogin model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                #region Succeed
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Doctor");
                }

                else
                {
                    if (_context.AppUsers.Any(e => e.Email == model.Email))
                    {
                        ModelState.AddModelError("", "Your password incorrect");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Your email incorrect");
                    };
                }
                #endregion
            }
            return View(model);

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
