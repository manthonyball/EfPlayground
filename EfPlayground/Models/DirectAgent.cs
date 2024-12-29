using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFGetStarted.Models
{
    [Table("DirectAgent", Schema = "dbo")]
    public class DirectAgent
    {
        [Key]
        public Guid Code { get; set; }
        public int? Active { get; set; }
        // public ICollection<MortgageAgent>? MortgageAgent { get; set; }
    }
}
