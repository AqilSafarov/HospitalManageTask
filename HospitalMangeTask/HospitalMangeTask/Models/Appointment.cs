using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMangeTask.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }


        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
