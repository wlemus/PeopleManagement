using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PeopleManagement.Domain;
using PeopleManagement.Infrastructure.Entities;

namespace PeopleManagement.Infrastructure.Mappings
{
   public class MappingProfileInfra: Profile
    {
        public MappingProfileInfra() {
            CreateMap<PersonEntity, Person>();
            CreateMap<Person,PersonEntity>();
            CreateMap<PhonePerson, PhonePersonEntity>();
            CreateMap<PhonePersonEntity, PhonePerson>();
            CreateMap<EmailPerson, EmailPersonEntity>();
            CreateMap<EmailPersonEntity, EmailPerson>();
            CreateMap<AddressPerson, AddressPersonEntity>();
            CreateMap<AddressPersonEntity, AddressPerson>();
        }
    }
}
