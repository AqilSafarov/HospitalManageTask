using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMangeTask.Models
{
    public class AppUser: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
    public class AppUserValidator : AbstractValidator<AppUser>
    {
        public AppUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bos ola bilmez")
                .MaximumLength(25).WithMessage("Maximum uzunluq 25 ola biler");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Bos ola bilmez")
                 .MaximumLength(25).WithMessage("Maximum uzunluq 25 ola biler");
         
        }
    }
}
