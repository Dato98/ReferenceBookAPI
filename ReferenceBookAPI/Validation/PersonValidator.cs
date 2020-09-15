using BLL.DTOs.Person;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReferenceBookAPI.Validation
{
    public class PersonValidator :AbstractValidator<PersonFormDTO>
    {
        public PersonValidator()
        {
            RuleFor(x => x.NameGeo).NotEmpty().Length(50);
            RuleFor(x => x.NameEng).NotEmpty().Length(50);
            RuleFor(x => x.SurnameEng).NotEmpty().Length(60);
            RuleFor(x => x.SurnameGeo).NotEmpty().Length(60);
            RuleFor(x => x.BirthDate).NotNull();
            RuleFor(x => x.Address).NotEmpty().Length(300);

        }
    }
}
