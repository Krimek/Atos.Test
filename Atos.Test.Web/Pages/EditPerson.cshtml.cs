using Atos.Test.Application.Features.EditPerson;
using Atos.Test.Application.Infrastructure;
using Atos.Test.Presentation.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Atos.Test.Web.Pages
{
    public class EditPersonModel : PageModel
    {
        private readonly ICommandHandler<EditPersonCommand> _commandHandler;
        private readonly IPersonPresentationRepository _presentationRepository;

        public EditPersonModel(ICommandHandler<EditPersonCommand> commandHandler, IPersonPresentationRepository presentationRepository)
        {
            this._commandHandler = commandHandler;
            this._presentationRepository = presentationRepository;
        }

        public void OnGet(int id)
        {
            PersonModel = this._presentationRepository.Get(id);
        }

        [BindProperty]
        public PersonModel PersonModel { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this._commandHandler.Handle(new EditPersonCommand(PersonModel.ID, PersonModel.Name, PersonModel.BankName, PersonModel.AccountBalance));

            return RedirectToPage("/PeopleIndex");
        }
    }
}
