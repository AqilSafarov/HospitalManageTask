using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMangeTask.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Rank { get; set; }
        public int Experience { get; set; }
        public List<Appointment> Appointment { get; set; }


    }
    public class DoctorValidator : AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bos ola bilmez")
                .MaximumLength(25).WithMessage("Maximum uzunluq 25 ola biler");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Bos ola bilmez")
                 .MaximumLength(25).WithMessage("Maximum uzunluq 25 ola biler");
            RuleFor(x => x.Rank).NotEmpty().WithMessage("Bos ola bilmez")
               .MaximumLength(50).WithMessage("Maximum uzunluq 25 ola biler");

        }
    }
}
