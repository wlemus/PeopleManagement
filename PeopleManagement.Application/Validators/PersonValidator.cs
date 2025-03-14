using FluentValidation;
using PeopleManagement.Domain;
using System;
using System.Linq;

namespace PeopleManagement.Application.Validators
{
   public class PersonValidator : AbstractValidator<Person> {
        public PersonValidator() {
            ///////////////////////////////////////////////////////II. VALIDACIONES CAMPOS OBLIGATORIOS Y FORMATOS///////////////////////////////////////////////
            RuleFor(p => p.IdentityDocument)
                .NotEmpty().WithMessage("El documento de identidad es obligatorio")                
               .Matches(@"^[a-zA-Z0-9]+$").WithMessage("El documento de identidad únicamente debe contener valores alfanuméricos");

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("El nombre es obligatorio")
             .Matches(@"^[a-zA-ZÁÉÍÓÚáéíóúÑñüÜ\s]+$").WithMessage("El nombre únicamente debe contener caracteres del alfabeto latino sin valores numéricos.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("El apellido es obligatorio")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres")
                 .Matches(@"^[a-zA-ZÁÉÍÓÚáéíóúÑñüÜ\s]+$").WithMessage("El apellido únicamente debe contener caracteres del alfabeto latino sin valores numéricos.");

            RuleFor(p => p.DateOfBirth)
                .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria")
                .LessThan(DateTime.Now).WithMessage("La fecha de nacimiento no puede ser en el futuro");

            ///////////////////////////////////////////////////////III. VALIDACIONES DE CONTACTO///////////////////////////////////////////////
            //Validar que tenga al menos un email o una dirección física
            RuleFor(p => p)
             .Must(p => p.Emails.Any() || p.Addresses.Any())
             .WithMessage("Debe registrar al menos un correo electrónico o una dirección física.");


            //No más de 2 teléfonos
            RuleFor(p => p.Phones)
                .Must(phones => phones.Count <= 2)
                .WithMessage("Solo se permiten hasta 2 números telefónicos.");

            // No más de 2 correos electrónicos
            RuleFor(p => p.Emails)
                .Must(emails => emails.Count <= 2)
                .WithMessage("Solo se permiten hasta 2 correos electrónicos.");

            // No más de 2 direcciones físicas
            RuleFor(p => p.Addresses)
                .Must(addresses => addresses.Count <= 2)
                .WithMessage("Solo se permiten hasta 2 direcciones físicas.");

        }
    }
}
