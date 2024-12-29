using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.Models
{
    [Table("MortgageAgent", Schema = "dbo")]
    [PrimaryKey(nameof(Number), nameof(RecordedDate))]
    public class MortgageAgent
    {
        public HubAgent? Code { get; set; }

        [Column("HubAgent")]
        [ForeignKey("HubAgent.Code")]
        public Guid? HubAgentCode { get; set; }

        public DirectAgent? Code2 { get; set; }
        [Column("DirectAgent")]
        [ForeignKey("DirectAgent.Code")]
        public Guid? DirectAgentCode { get; set; }
        public int? Active { get; set; }
        public int Number { get; set; }
        public DateTime RecordedDate { get; set; }
    }
}
