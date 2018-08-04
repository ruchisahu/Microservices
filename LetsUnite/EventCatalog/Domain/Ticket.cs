using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCatalog.Domain
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
     
    }
}