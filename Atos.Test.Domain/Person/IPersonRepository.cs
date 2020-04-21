using System.Collections.Generic;

namespace Atos.Test.Domain.Person
{
    public interface IPersonRepository
    {
        void Add(PersonDto entity);

        void Edit(PersonDto entity);

        void Remove(int id);

        PersonDto Get(int id);

        IEnumerable<PersonDto> GetAll();

        int? GetBankID(string name);
    }
}
