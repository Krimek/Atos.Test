using System;
using System.Collections.Generic;
using System.Text;
using Atos.Test.Application.Infrastructure;
using Atos.Test.Domain.Person;

namespace Atos.Test.Application.Features.RemovePerson
{
    public class RemovePersonCommandHandler :ICommandHandler<RemovePersonCommand>
    {
        private readonly IPersonFactory _personFactory;
        private readonly IPersonRepository _personRepository;

        public RemovePersonCommandHandler(IPersonFactory personFactory, IPersonRepository personRepository)
        {
            this._personFactory = personFactory;
            this._personRepository = personRepository;
        }
        public void Handle(RemovePersonCommand command)
        {
            var person = this._personFactory.Create(command.ID, this._personRepository);
            person.Remove(_personRepository);
        }
    }
}
