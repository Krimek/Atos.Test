namespace Atos.Test.Application.Features.RemovePerson
{
    public class RemovePersonCommand
    {
        public int ID { get; set; }

        public RemovePersonCommand(int id)
        {
            ID = id;
        }
    }
}
