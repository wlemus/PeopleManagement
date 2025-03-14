using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Domain.Interfaces
{
    public interface IPersonRepository
    {
        void AddPerson(Person person);
        bool PersonExists(int identityDocument);
           
        }
    }

