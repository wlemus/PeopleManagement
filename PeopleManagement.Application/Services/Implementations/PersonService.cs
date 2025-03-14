using PeopleManagement.Application.Services.Interfaces;
using PeopleManagement.Application.Validators;
using PeopleManagement.Domain;
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

        public bool AddPerson(Person person) {
            try {
                var validator = new PersonValidator();
                var validationResult = validator.Validate(person);
                if (!validationResult.IsValid) {
                    Console.WriteLine("Errores de validación:");
                    foreach (var error in validationResult.Errors) {
                        Console.WriteLine($"- {error.ErrorMessage}");
                    }
                    return false;
                }

                _personRepository.AddPerson(person);
                return true;
            } catch ( DuplicateIdentityException ex ) {
                ///////////////////////////////////////////////////////I. VALIDACION DOCUMENTO ID DUPLICADO///////////////////////////////////////////////
                if (ex.InnerException.InnerException.Message.Contains("IX_IdentityDocumentPerson"))             
                    Console.WriteLine($"El documento de identidad '{person.IdentityDocument}' ya existe.");
                else
                    Console.WriteLine($"Existen datos duplicados en la persona que se requiere agregar.");
            }
            catch (Exception ex) {
                Console.WriteLine($"Ha ocurrido un error agregando a la persona: {ex.Message}");
           
            }
            return false;
        }


        public Person GetPersonById(int id) {
            throw new NotImplementedException();
        }

       
    }
}
