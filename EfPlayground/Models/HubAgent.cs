using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFGetStarted.Models
{
    public class HubAgent
    {
        [Key]
        public Guid Code { get; set; }
        public int? Active { get; set; }
    }
}
