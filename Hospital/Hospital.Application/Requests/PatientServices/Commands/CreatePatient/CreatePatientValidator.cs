using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Application.Requests.PatientServices.Commands.CreatePatient
{
    public class CreatePatientValidator : AbstractValidator<CreatePatientQuery>
    {
        public CreatePatientValidator()
        {
            RuleFor(v => v.FileNo).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().Length(3, 100);
            RuleFor(v => v.CitizenId).NotEmpty().MaximumLength(11);
            RuleFor(v => v.BirthDate).NotEmpty();
            RuleFor(v => v.Gender).NotEmpty();
            RuleFor(v => v.Natinality).NotEmpty();
            RuleFor(v => v.PhoneNumber).NotEmpty().MaximumLength(15);
            RuleFor(v => v.Email).NotEmpty().EmailAddress();
            RuleFor(v => v.Country).NotEmpty().MaximumLength(200);
            RuleFor(v => v.City).NotEmpty().MaximumLength(200);
            RuleFor(v => v.Street).NotEmpty().MaximumLength(300);
            RuleFor(v => v.Address1).NotEmpty().MaximumLength(500);
            RuleFor(v => v.Address2).NotEmpty().MaximumLength(500);
            RuleFor(v => v.ContactPerson).NotEmpty().MaximumLength(100);
            RuleFor(v => v.ContactRelation).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ContactPhone).NotEmpty().MaximumLength(15);
            RuleFor(v => v.FirstVisitDate).NotEmpty();
        }
    }
}
