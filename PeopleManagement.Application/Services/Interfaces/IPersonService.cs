using PeopleManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Application.Services.Interfaces
{
    public interface IPersonService
    {
        bool  AddPerson(Person person);
        Person GetPersonById(int id);       
    }
}
