using PeopleManagement.Application.Services.Interfaces;
using PeopleManagement.Application.Validators;
using PeopleManagement.Domain;
using PeopleManagement.Domain.Common;
using PeopleManagement.Domain.Exceptions;
using PeopleManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Application
{
    public class PersonService: IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository) {
            _personRepository = personRepository;
        }

        public Result<bool> AddPerson(Person person) {
            string errors = string.Empty;
            try {
              
                var validator = new PersonValidator();
                var validationResult = validator.Validate(person);
                if (!validationResult.IsValid) {
                    errors = string.Join(Environment.NewLine, validationResult.Errors.Select(error => $"- {error.ErrorMessage}"));
                    return Result<bool>.Failure($"Errores de validación: {errors}");
                }

                _personRepository.AddPerson(person);
                return Result<bool>.Success(true);
            } catch ( DuplicateIdentityException ex ) {
                ///////////////////////////////////////////////////////I. VALIDACION DOCUMENTO ID DUPLICADO///////////////////////////////////////////////
                if (ex.InnerException.InnerException.Message.Contains("IX_IdentityDocumentPerson"))
                    errors=$"El documento de identidad '{person.IdentityDocument}' ya existe.";
                else
                   errors=$"Existen datos duplicados en la persona que se requiere agregar.";
            }
            catch (Exception ex) {
                errors = $"Ha ocurrido un error agregando a la persona: {ex.Message}";
           
            }
             return Result<bool>.Failure(errors);
        }
       
    }
}
