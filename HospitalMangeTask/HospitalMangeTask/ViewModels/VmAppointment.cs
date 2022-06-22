using HospitalMangeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMangeTask.ViewModels
{
    public class VmAppointment
    {
        public List<Doctor> Doctors { get; set; }
        public Doctor Doctor { get; set; }
        public AppUser AppUser { get; set; }
        public Appointment Appointment { get; set; }
        public List<Appointment> Appointments { get; set; }


    }
}
