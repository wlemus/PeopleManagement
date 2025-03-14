using PeopleManagement.Domain;
using PeopleManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Result<bool>  AddPerson(Person person);  
    }
}
