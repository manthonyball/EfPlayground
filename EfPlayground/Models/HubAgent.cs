using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFGetStarted.Models
{
    [Table("HubAgent", Schema = "dbo")]
    public class HubAgent
    {
        [Key]
        public Guid Code { get; set; }
        public int? Active { get; set; }
       // public ICollection<MortgageAgent>? MortgageAgent { get; set; }
    }
}
