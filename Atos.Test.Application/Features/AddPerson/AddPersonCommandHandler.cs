using Atos.Test.Application.Infrastructure;
using Atos.Test.Domain.Person;

namespace Atos.Test.Application.Features.AddPerson
{
    public class AddPersonCommandHandler : ICommandHandler<AddPersonCommand>
    {
        private readonly IPersonFactory _personFactory;
        private readonly IPersonRepository _personRepository;

        public AddPersonCommandHandler(IPersonRepository personRepository, IPersonFactory personFactory)
        {
            this._personRepository = personRepository;
            this._personFactory = personFactory;
        }
        public void Handle(AddPersonCommand command)
        {
            var person =
                this._personFactory.Create(command.Name, command.BankName, command.AccountBalance);
            person.Add(this._personRepository);
        }
    }
}
