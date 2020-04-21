using System.Collections.Generic;

namespace Atos.Test.Presentation.Person
{
    public interface IPersonPresentationRepository
    {
        PersonModel Get(int id);

        IEnumerable<PersonModel> GetAll();
    }
}
