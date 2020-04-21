using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atos.Test.Infrastructure.Entity
{
    [Table("People")]
    public class People
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int? IDBank { get; set; }

        public int AccountBalance { get; set; }

        public virtual Bank Bank { get; set; }
    }
}
