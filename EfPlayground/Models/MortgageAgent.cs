using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.Models
{
    public class MortgageAgent
    {
        public Guid? HubAgentCode { get; set; }
        public Guid? DirectAgentCode { get; set; }
        public int? Active { get; set; }
        public int Number { get; set; }
        public DateTime RecordedDate { get; set; }
    }
}
