using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalog.Domain
{
    public enum EventPriceType
    {
        Free,Paid
    }

    public enum EventCategory
    {
        Music,Kids,Sports,Fitness,Tech,Cooking,Travel,Fashion,Holiday
    }


    public class Eventcatalog
    {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        [ForeignKey("PlaceId")]
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
        //  public int TicketId { get; set; }

        //  public int TicketI { get; set; }
        public DateTime EventDate { get; set; }

        public Decimal EventPrice { get; set; }

        public string EventImageURL { get; set; }

        public EventPriceType EventPriceType { get; set; }

        public EventCategory EventCategory { get; set; }
        [NotMapped]
      //  public Place Place { get; set; }
        public User User { get; set; }
        public List<Ticket> Tickets { get; set; }
          public int TicketId { get; internal set; }
          public virtual Ticket Ticket { get; set; }









    }
}
