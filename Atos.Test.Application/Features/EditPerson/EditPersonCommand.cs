namespace Atos.Test.Application.Features.EditPerson
{
    public class EditPersonCommand
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string BankName { get; set; }

        public int AccountBalance { get; set; }

        public EditPersonCommand(int id, string name, string bankName, int accountBalance)
        {
            ID = id;
            Name = name;
            AccountBalance = accountBalance;
            BankName = bankName;
        }
    }
}
