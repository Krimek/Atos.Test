using System.Collections.Generic;
using System.Linq;
using Atos.Test.Domain.Person;

namespace Atos.Test.Presentation.Person
{
    public class PersonPresentationRepository : IPersonPresentationRepository
    {
        private readonly IPersonRepository _personRepository;

        public PersonPresentationRepository(IPersonRepository personRepository)
        {
            this._personRepository = personRepository;
        }

        public PersonModel Get(int id)
        {
            var entity = this._personRepository.Get(id);
            return new PersonModel
            {
                ID = entity.ID,
                Name = entity.Name,
                BankName = entity.BankName,
                AccountBalance = entity.AccountBalance
            };
        }

        public IEnumerable<PersonModel> GetAll()
        {
            var entities = this._personRepository.GetAll();

            return entities.Select(entity => new PersonModel
            {
                ID = entity.ID,
                Name = entity.Name,
                BankName = entity.BankName,
                AccountBalance = entity.AccountBalance
            }).ToList();
        }
    }
}
