using System;
using System.Collections.Generic;
using System.Text;

namespace Atos.Test.Domain.Person
{
    public interface IPersonRepository
    {
        void Add(Infrastructure.Entity.People entity);

        void Edit(Infrastructure.Entity.People entity);

        void Remove(int id);

        PersonDto Get(int id);

        IEnumerable<PersonDto> GetAll();

        int? GetBankID(string name);
    }
}
