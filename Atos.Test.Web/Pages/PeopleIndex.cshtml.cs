using System.Collections.Generic;
using Atos.Test.Application.Features.RemovePerson;
using Atos.Test.Application.Infrastructure;
using Atos.Test.Presentation.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Atos.Test.Web.Pages
{
    public class PeopleIndexModel : PageModel
    {
        private readonly IPersonPresentationRepository _personPresentationRepository;
        private readonly ICommandHandler<RemovePersonCommand> _commandHandler;

        public PeopleIndexModel(IPersonPresentationRepository personPresentationRepository, ICommandHandler<RemovePersonCommand> commandHandler)
        {
            this._personPresentationRepository = personPresentationRepository;
            this._commandHandler = commandHandler;
        }

        public IEnumerable<PersonModel> People { get; set; }

        public IActionResult OnPostDelete(int id)
        {
            this._commandHandler.Handle(new RemovePersonCommand(id));
            return RedirectToPage("/PeopleIndex");
        }

        public void OnGet()
        {
            People = this._personPresentationRepository.GetAll();
        }
    }
}
