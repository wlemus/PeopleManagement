using AutoMapper;
using PeopleManagement.Domain;
using PeopleManagement.Domain.Interfaces;
using PeopleManagement.Infrastructure.Entities;
using PeopleManagement.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using PeopleManagement.Domain.Exceptions;
using System.Threading.Tasks;

namespace PeopleManagement.Infrastructure.Repositories
{
   public class PersonRepository : IPersonRepository {
        private readonly IMapper _mapper;
        private readonly PeopleDBContext _context;


        public PersonRepository(PeopleDBContext context) {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingProfileInfra());
            });

            _mapper = config.CreateMapper();
            _context = context;
        }
        public  void AddPerson(Person person) {
            try {                             
                var personEntity = _mapper.Map<PersonEntity>(person);
                _context.Person.Add(personEntity);
                _context.SaveChanges();
           
            } catch (DbUpdateException ex) {
                // Extraer el mensaje del error SQL
                var sqlEx = ex.GetBaseException() as SqlException;
                if (sqlEx != null) 
                    if (sqlEx.Number == 2601 || sqlEx.Number == 2627)  // Errores de clave única      
                        throw new DuplicateIdentityException($"Información duplicada en la tabla", ex.InnerException);
                
                throw;
            }
        }

    }
}
