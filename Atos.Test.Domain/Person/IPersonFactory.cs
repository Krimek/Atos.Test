using System;
using System.Collections.Generic;
using System.Text;

namespace Atos.Test.Domain.Person
{
    public interface IPersonFactory
    {
        Person Create(int id, IPersonRepository personRepository);
        
        Person Create(string commandName, string commandBankName, int commandAccountBalance);
    }
}
