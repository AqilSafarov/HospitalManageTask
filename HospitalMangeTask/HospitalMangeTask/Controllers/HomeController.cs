using HospitalMangeTask.Models;
using HospitalMangeTask.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMangeTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public HomeController(AppDbContext context, UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager,RoleManager<IdentityRole>rolemanager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _rolemanager = rolemanager;
        }

        public IActionResult Index()
        {
            VmAppointment model = new VmAppointment();
            model.Doctors = _context.Doctors.ToList();
            model.Appointments = _context.Appointments.ToList();
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
                    return RedirectToAction("Appointment", "Home");
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
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(VmRegistor model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser() { Name = model.Name, Surname = model.Surname, Email = model.Email, UserName = model.Email };
                var result = await _userManager.CreateAsync(appUser, model.Password);

                #region Succed
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(appUser, false);
                    await _userManager.AddToRoleAsync(appUser, "Member");

                    return RedirectToAction("Appointment", "Home");
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
        public IActionResult Appointment()
        {
            VmAppointment model = new VmAppointment();
            model.Doctors = _context.Doctors.ToList();
            model.Doctor = _context.Doctors.FirstOrDefault();
            model.AppUser = _context.AppUsers.FirstOrDefault();
            return View(model);
            
        }
        [HttpPost]
        public IActionResult AppointmentPost(VmAppointment model)
        {
            if (ModelState.IsValid)
            {
                model.Appointment.CreatedDate = DateTime.Now;
                _context.Appointments.Add(model.Appointment);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");

        }
        //public async Task CreateRoles()
        //{
        //    await _rolemanager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _rolemanager.CreateAsync(new IdentityRole { Name = "Member" });
        //}

    }
}
