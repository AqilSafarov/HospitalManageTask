using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMangeTask.ViewModels
{
    public class VmRegistor
    {

        [MaxLength(25), Required]
        public string Name { get; set; }
        [MaxLength(25)]
        public string Surname { get; set; }
        [MaxLength(50), Required]
        public string Email { get; set; }
        [MaxLength(50), Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [MaxLength(50), Required]
        [DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
