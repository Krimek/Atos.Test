using Atos.Test.Application.Features.EditPerson;
using Atos.Test.Application.Infrastructure;
using Atos.Test.Presentation.People;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Atos.Test.Web.Pages
{
    public class EditPeopleModel : PageModel
    {
        private readonly ICommandHandler<EditPersonCommand> _commandHandler;
        private readonly IPeoplePresentationRepository _presentationRepository;

        public EditPeopleModel(ICommandHandler<EditPersonCommand> commandHandler, IPeoplePresentationRepository presentationRepository)
        {
            this._commandHandler = commandHandler;
            this._presentationRepository = presentationRepository;
        }

        public void OnGet(int id)
        {
            PeopleModel = this._presentationRepository.Get(id);
        }

        [BindProperty]
        public PeopleModel PeopleModel { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this._commandHandler.Handle(new EditPersonCommand(PeopleModel.ID, PeopleModel.Name, PeopleModel.BankName, PeopleModel.AccountBalance));

            return RedirectToPage("/PeopleIndex");
        }
    }
}
