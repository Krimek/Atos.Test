using System;
using System.Collections.Generic;
using System.Text;

namespace Atos.Test.Presentation.People
{
    public interface IPeoplePresentationRepository
    {
        PeopleModel Get(int id);

        IEnumerable<PeopleModel> GetAll();
    }
}
