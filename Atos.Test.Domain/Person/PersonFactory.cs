namespace Atos.Test.Domain.Person
{
    public class PersonFactory : IPersonFactory
    {
        public Person Create(int id, IPersonRepository personRepository)
        {
            return new Person(id, personRepository);
        }

        public Person Create(string commandName, string commandBankName, int commandAccountBalance)
        {
            return new Person(commandName, commandBankName, commandAccountBalance);
        }
    }
}
