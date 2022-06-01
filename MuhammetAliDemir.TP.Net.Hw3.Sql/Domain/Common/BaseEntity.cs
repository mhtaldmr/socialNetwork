using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuhammetAliDemir.TP.Net.Hw3.Sql.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        [Column(Order=0)]
        public int Id { get; set; }

        [Column(Order=1)]
        public string? Name { get; set; }
    }
}
