using Atos.Test.Domain.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atos.Test.Presentation.People
{
    public class PeoplePresentationRepository : IPeoplePresentationRepository
    {
        private readonly IPersonRepository _personRepository;

        public PeoplePresentationRepository(IPersonRepository personRepository)
        {
            this._personRepository = personRepository;
        }

        public PeopleModel Get(int id)
        {
            var entity = this._personRepository.Get(id);
            return new PeopleModel
            {
                ID = entity.ID,
                Name = entity.Name,
                BankName = entity.BankName,
                AccountBalance = entity.AccountBalance
            };
        }

        public IEnumerable<PeopleModel> GetAll()
        {
            var entities = this._personRepository.GetAll();

            return entities.Select(entity => new PeopleModel
            {
                ID = entity.ID,
                Name = entity.Name,
                BankName = entity.BankName,
                AccountBalance = entity.AccountBalance
            }).ToList();
        }
    }
}
