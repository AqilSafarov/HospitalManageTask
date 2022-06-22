using HospitalMangeTask.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMangeTask
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }





    }
}
