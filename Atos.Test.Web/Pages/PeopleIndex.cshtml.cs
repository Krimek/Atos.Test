using System.Collections.Generic;
using Atos.Test.Application.Features.RemovePerson;
using Atos.Test.Application.Infrastructure;
using Atos.Test.Presentation.People;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Atos.Test.Web.Pages
{
    public class PeopleIndexModel : PageModel
    {
        private readonly IPeoplePresentationRepository _peoplePresentationRepository;
        private readonly ICommandHandler<RemovePersonCommand> _commandHandler;

        public PeopleIndexModel(IPeoplePresentationRepository peoplePresentationRepository, ICommandHandler<RemovePersonCommand> commandHandler)
        {
            this._peoplePresentationRepository = peoplePresentationRepository;
            this._commandHandler = commandHandler;
        }

        public IEnumerable<PeopleModel> People { get; set; }

        public IActionResult OnPostDelete(int id)
        {
            this._commandHandler.Handle(new RemovePersonCommand(id));
            return RedirectToPage("/PeopleIndex");
        }

        public void OnGet()
        {
            People = this._peoplePresentationRepository.GetAll();
        }
    }
}
