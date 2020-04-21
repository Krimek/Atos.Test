using Atos.Test.Infrastructure;
using Atos.Test.Infrastructure.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Atos.Test.Domain.Person
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TestContext _context;

        public PersonRepository(TestContext context)
        {
            _context = context;
        }

        public void Add(PersonDto entity)
        {
            this._context.People.Add(new People()
            {
                AccountBalance = entity.AccountBalance,
                IDBank = entity.BankID,
                Name = entity.Name
            });
            this._context.SaveChanges();
        }

        public void Edit(PersonDto entity)
        {
            var personEntity = GetEntity(entity.ID);
            personEntity.Name = entity.Name;
            personEntity.IDBank = entity.BankID;
            personEntity.AccountBalance = entity.AccountBalance;
            this._context.SaveChanges();
        }

        public void Remove(int id)
        {
            this._context.People.Remove(GetEntity(id));
            this._context.SaveChanges();
        }

        public PersonDto Get(int id)
        {
            var personDto = this._context.People.Select(x => new PersonDto
            {
                ID = x.ID,
                Name = x.Name,
                BankName = x.Bank.Name,
                AccountBalance = x.AccountBalance,
                BankID = x.IDBank
            }).FirstOrDefault(x => x.ID == id);

            return personDto;
        }

        public IEnumerable<PersonDto> GetAll()
        {
            return this._context.People.Select(x => new PersonDto
            {
                ID = x.ID, Name = x.Name, BankName = x.Bank.Name, AccountBalance = x.AccountBalance, BankID = x.IDBank
            }).ToList();
        }

        private People GetEntity(int id)
        {
            return this._context.People.FirstOrDefault(x => x.ID == id);
        }

        public int? GetBankID(string name)
        {
            return this._context.Bank.FirstOrDefault(x => x.Name == name).ID;
        }
    }
}
