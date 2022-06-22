using HospitalMangeTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMangeTask.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin")]

    public class DoctorController : Controller
    {
        private readonly AppDbContext _context;

        public DoctorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Doctor> doctors = _context.Doctors.ToList();
            return View(doctors);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor model)
        {
            if (ModelState.IsValid)
            {
                _context.Doctors.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();

        }
        public IActionResult Update(int? doctorId)
        {
            Doctor doctor = _context.Doctors.Find(doctorId);
            return View(doctor);
        }
        [HttpPost]
        public IActionResult Update(Doctor model)
        {
            if (ModelState.IsValid)
            {
                _context.Doctors.Update(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();

        }
        public IActionResult Delete(int? doctorId)
        {
            Doctor doctor = _context.Doctors.Find(doctorId);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
