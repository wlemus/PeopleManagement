using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeopleManagement.Application;
using PeopleManagement.Domain;
using PeopleManagement.Domain.Exceptions;
using PeopleManagement.Domain.Interfaces;
using PeopleManagement.Infrastructure;
using PeopleManagement.Infrastructure.Entities;
using PeopleManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;

namespace PeopleManagement.Application.Tests {
    [TestClass]
    public class PersonServiceTests {
        private PeopleDBContext _dbContext;
        private PersonService _personService;

        [TestInitialize]
        public void Setup() {
            // Usamos LocalDB para pruebas en .NET Framework
            string connectionString = @"Server=DESKTOP-UNJOHJJ\SQLEXPRESS;Database=PeopleManagementDB;Encrypt=False;Trusted_Connection=True;";

            _dbContext = new PeopleDBContext(connectionString);
        
            var personRepository = new PersonRepository(_dbContext);
            _personService = new PersonService(personRepository);
                    }

        [TestMethod]
        public void AddPerson_ShouldThrowException_WhenIdentityDocumentIsDuplicated() {
            // Arrange
            var person = new Person {
                IdentityDocument = "CE384796",
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Now,
                Phones = new List<PhonePerson> { new PhonePerson { PhoneNumber = "123456789", Type = "Home" }},
                Emails = new List<EmailPerson> { new EmailPerson { Email = "w.xxsd@gmail.com", Type = "Personal" } },
                Addresses = new List<AddressPerson> { new AddressPerson { Address = "Jalapa, Guatemala", Type = "Home" } }
            };

            // Act
            var result = _personService.AddPerson(person);

            // Assert
            Assert.IsTrue(result.HasError);
            Assert.AreEqual($"El documento de identidad '{person.IdentityDocument}' ya existe.", result.Error);
        }

        [TestMethod]
        public void AddPerson_ShouldReturnFalse_WhenRequiredFieldsAreMissing() {
            // Arrange
            var person = new Person { IdentityDocument = "", FirstName = "", LastName = "", DateOfBirth = DateTime.MinValue };

            // Act
            var result = _personService.AddPerson(person);

            // Assert
            Assert.IsTrue(result.HasError);
        }

        [TestMethod]
        public void AddPerson_ShouldReturnFalse_WhenNamesContainNumericValues() {
            // Arrange
            var person = new Person { IdentityDocument = "123456", FirstName = "John1", LastName = "Doe2", DateOfBirth = DateTime.Now };

            // Act
            var result = _personService.AddPerson(person);

            // Assert
            Assert.IsTrue(result.HasError);
        }

        [TestMethod]
        public void AddPerson_ShouldReturnFalse_WhenIdentityDocumentIsNotAlphanumeric() {
            // Arrange
            var person = new Person { IdentityDocument = "123@456", FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.Now };

            // Act
            var result = _personService.AddPerson(person);

            // Assert
            Assert.IsTrue(result.HasError);
        }

        [TestMethod]
        public void AddPerson_ShouldReturnFalse_WhenNoContactInformationIsProvided() {
            // Arrange
            var person = new Person {
                IdentityDocument = "123456",
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Now,
                Phones = new List<PhonePerson>(),
                Emails = new List<EmailPerson>(),
                Addresses = new List<AddressPerson>()
            };

            // Act
            var result = _personService.AddPerson(person);

            // Assert
            Assert.IsTrue(result.HasError);
        }

        [TestMethod]
        public void AddPerson_ShouldReturnFalse_WhenMoreThanTwoContactInformationIsProvided() {
            // Arrange
            var person = new Person {
                IdentityDocument = "123456",
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Now,
                Phones = new List<PhonePerson> { new PhonePerson(), new PhonePerson(), new PhonePerson() },
                Emails = new List<EmailPerson> { new EmailPerson(), new EmailPerson(), new EmailPerson() },
                Addresses = new List<AddressPerson> { new AddressPerson(), new AddressPerson(), new AddressPerson() }
            };

            // Act
            var result = _personService.AddPerson(person);

            // Assert
            Assert.IsTrue(result.HasError);
        }

        [TestMethod]
        public void AddPerson_ShouldReturnTrue_WhenValidPersonIsProvided() {
            // Arrange
            var person = new Person {
                IdentityDocument = "1025325985",
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Now,
                Phones = new List<PhonePerson> { new PhonePerson { PhoneNumber = "123456789", Type = "Home" } },
                Emails = new List<EmailPerson> { new EmailPerson { Email = "John.Doe@gmail.com", Type = "Personal" } },
                Addresses = new List<AddressPerson> { new AddressPerson { Address = "Bogota, Colombia", Type = "Home" } }
            };

            // Act
            var result = _personService.AddPerson(person);

            // Assert
            Assert.IsTrue(result.IsSuccess);
        }
    }
}
