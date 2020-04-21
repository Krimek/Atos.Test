using Atos.Test.Application.Infrastructure;
using Atos.Test.Domain.Person;

namespace Atos.Test.Application.Features.EditPerson
{
    public class EditPersonCommandHandler : ICommandHandler<EditPersonCommand>
    {
        private readonly IPersonFactory _personFactory;
        private readonly IPersonRepository _personRepository;

        public EditPersonCommandHandler(IPersonRepository personRepository, IPersonFactory personFactory)
        {
            this._personRepository = personRepository;
            this._personFactory = personFactory;
        }

        public void Handle(EditPersonCommand command)
        {
            var person = this._personFactory.Create(command.ID, this._personRepository);
            person.Edit(command.Name, command.BankName, command.AccountBalance, this._personRepository);
        }
    }
}
