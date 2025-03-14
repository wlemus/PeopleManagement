﻿using Microsoft.Extensions.DependencyInjection;
using PeopleManagement.Application.Services.Interfaces;
using PeopleManagement.ConsolTest.App_Start;
using PeopleManagement.Domain;
using PeopleManagement.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.ConsolTest {
    class Program {
        static void Main(string[] args) {

            // Configurar DI
            var serviceProvider = DependencyInjectionConfig.ConfigureServices();

            // Obtener la instancia de la clase inyectada (PersonService)
            var personService = serviceProvider.GetRequiredService<IPersonService>();
            var newPerson = new Person {
                IdentityDocument = "80125015",
                FirstName = "NICOLAS",
                LastName = "BOHORQUEZ",
                DateOfBirth = new DateTime(1990, 5, 15),
                Emails = new List<EmailPerson> {
                        new EmailPerson { Email = "w.xxsd@gmail.com",  Type="Personal"}},
                Addresses = new List<AddressPerson> {
                        new AddressPerson { Address = "Jalapa, Guatemala", Type="Home"}},
                Phones = new List<PhonePerson> {
                        new PhonePerson { PhoneNumber = "987654321", Type = "Mobile" },
                        new PhonePerson { PhoneNumber = "987654321", Type = "Mobile" }
                    }
            };
          var resultAddPerson =  personService.AddPerson(newPerson);

            if (resultAddPerson.IsSuccess) {
                Console.WriteLine("Persona agregada correctamente");
            } else {
                Console.WriteLine($"Error: {resultAddPerson.Error}");
            }
            Console.ReadLine();
            // personService.AddPerson(newPerson);

        }
    }
}
