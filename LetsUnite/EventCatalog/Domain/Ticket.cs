using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCatalog.Domain
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
     //   public int EventForeignKey { get; set; }
     //   public Eventcatalog Eventcatalog{ get;set; }

        /*  [ForeignKey("EventForeignKey")]

          public Eventcatalog Eventcatalog { get; set; }
       */
    }
}