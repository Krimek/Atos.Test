using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atos.Test.Infrastructure.Entity
{
    [Table("Bank")]
    public class Bank
    {
        public int ID { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<People> People { get; set; } = new HashSet<People>();
    }
}
