namespace Atos.Test.Domain.Person
{
    public class Person
    {
        private readonly int _commandID;
        private readonly string _commandName;
        private readonly string _commandBankName;
        private readonly int _commandAccountBalance;

        internal Person(int commandID, IPersonRepository personRepository)
        {
            this._commandID = commandID;

            var personEntity = personRepository.Get(this._commandID);

            this._commandName = personEntity.Name;
            this._commandBankName = personEntity.BankName;
            this._commandAccountBalance = personEntity.AccountBalance;
        }

        internal Person(string commandName, string commandBankName, int commandAccountBalance)
        {
            this._commandName = commandName;
            this._commandBankName = commandBankName;
            this._commandAccountBalance = commandAccountBalance;
        }

        public void Add(IPersonRepository personRepository)
        {
            int? bankId = personRepository.GetBankID(this._commandBankName);
            personRepository.Add(new Infrastructure.Entity.People
            {
                Name = this._commandName,
                IDBank = bankId,
                AccountBalance = this._commandAccountBalance
            });
        }

        public void Edit(string name, string bankName, int accountBalance, IPersonRepository personRepository)
        {
            int? bankId = personRepository.GetBankID(bankName);
            personRepository.Edit(new Infrastructure.Entity.People
            {
                ID = this._commandID,
                Name = name,
                IDBank = bankId,
                AccountBalance = accountBalance
            });
        }

        public void Remove(IPersonRepository personRepository)
        {
            personRepository.Remove(this._commandID);
        }
    }
}
