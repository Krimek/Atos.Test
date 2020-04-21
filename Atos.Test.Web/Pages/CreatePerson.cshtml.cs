using Atos.Test.Application.Features.AddPerson;
using Atos.Test.Application.Infrastructure;
using Atos.Test.Presentation.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Atos.Test.Web.Pages
{
    public class CreatePersonModel : PageModel
    {
        private readonly ICommandHandler<AddPersonCommand> _commandHandler;

        public CreatePersonModel(ICommandHandler<AddPersonCommand> commandHandler)
        {
            this._commandHandler = commandHandler;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PersonModel PersonModel { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this._commandHandler.Handle(new AddPersonCommand(PersonModel.Name, PersonModel.BankName, PersonModel.AccountBalance));

            return RedirectToPage("/PeopleIndex");
        }
    }
}
