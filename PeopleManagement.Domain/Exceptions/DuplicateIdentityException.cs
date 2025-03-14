using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Domain.Exceptions
{
 public   class DuplicateIdentityException : Exception {
        public DuplicateIdentityException(string message) : base(message) { }

        public DuplicateIdentityException(string message, Exception innerException) : base(message, innerException) { }
    }    
}
