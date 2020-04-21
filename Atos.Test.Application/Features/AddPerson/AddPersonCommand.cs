namespace Atos.Test.Application.Features.AddPerson
{
    public class AddPersonCommand
    {
        public string Name { get; set; }

        public string BankName { get; set; }

        public int AccountBalance { get; set; }

        public AddPersonCommand(string name, string bankName, int accountBalance)
        {
            Name = name;
            AccountBalance = accountBalance;
            BankName = bankName;
        }
    }
}
