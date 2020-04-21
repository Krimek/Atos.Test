using Atos.Test.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using Atos.Test.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace Atos.Test.Domain.Person
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TestContext _context;

        public PersonRepository(TestContext context)
        {
            _context = context;
        }

        public void Add(Infrastructure.Entity.People entity)
        {
            this._context.People.Add(entity);
            this._context.SaveChanges();
        }

        public void Edit(Infrastructure.Entity.People entity)
        {
            var personEntity = GetEntity(entity.ID);
            personEntity.Name = entity.Name;
            personEntity.IDBank = entity.IDBank;
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
            }).ToList();
            return personDto.FirstOrDefault(x => x.ID == id);
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
