using Atos.Test.Application.Features.AddPerson;
using Atos.Test.Application.Infrastructure;
using Atos.Test.Presentation.People;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Atos.Test.Web.Pages
{
    public class CreatePeopleModel : PageModel
    {
        private readonly ICommandHandler<AddPersonCommand> _commandHandler;

        public CreatePeopleModel(ICommandHandler<AddPersonCommand> commandHandler)
        {
            this._commandHandler = commandHandler;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PeopleModel PeopleModel { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this._commandHandler.Handle(new AddPersonCommand(PeopleModel.Name, PeopleModel.BankName, PeopleModel.AccountBalance));

            return RedirectToPage("/PeopleIndex");
        }
    }
}
