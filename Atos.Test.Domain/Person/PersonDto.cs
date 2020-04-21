using System;
using System.Collections.Generic;
using System.Text;

namespace Atos.Test.Domain.Person
{
    public class PersonDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string BankName { get; set; }

        public int AccountBalance { get; set; }

        public int? BankID { get; set; }
    }
}
