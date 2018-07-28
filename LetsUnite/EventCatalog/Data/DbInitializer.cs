using EventCatalog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalog.Data
{
    public class DbInitializer
    {
       // List<Ticket> ticket1 = new List<Ticket>();
        

        public static async Task SeedAsync(EventCatalogContext context)
        {
            context.Database.Migrate();
            if (!context.Places.Any())
            {
                context.Places.AddRange
                    (GetPreconfiguredPlaces());
                await context.SaveChangesAsync();
            }
            if (!context.Tickets.Any())
            {
                context.Tickets.AddRange
                    (GetPreconfiguredTickets());
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange
                    (GetPreconfiguredUsers());
                context.SaveChanges();
            }
            if (!context.Eventcatalogs.Any())
            {
                context.Eventcatalogs.AddRange
                    (GetPreconfiguredevent());
                context.SaveChanges();
            }
        }
        static IEnumerable<Place> GetPreconfiguredPlaces()
        {
            return new List<Place>()
            {
                new Place() { PlaceId=2,Address="Redmond", PlacePrice=200.00M},
                 new Place() { PlaceId=3,Address="Bellevue", PlacePrice=100.00M}

            };
        }
        static IEnumerable<Ticket> GetPreconfiguredTickets()
        {
            return new List<Ticket>()
            {

                 new Ticket() { TicketId=2},
                 new Ticket() { TicketId=3},
                 new Ticket() { TicketId=4}

            };
            
        }
        static IEnumerable<User> GetPreconfiguredUsers()
        {
            return new List<User>()
            {

                new User() { UserId=2, Password= "a",Email="test1@test1",Name="joe",BillingAddress="address1",EventId=101,TicketId=1, CreditCardNo=456},

            };
        }

        static IEnumerable<Eventcatalog> GetPreconfiguredevent()
        {

            DateTime date1 = new DateTime(2014, 6, 14, 6, 32, 0);
            return new List<Eventcatalog>()
            {
               new Eventcatalog() {EventName="event1",Description="",Location="redmond",PlaceId1=1,Ticket=2,EventDate=date1,EventPrice=101.2M,EventImageURL="https://github.com/ruchisahu/dataAnalysis_cloud9/blob/master/age.png",EventPriceType=EventPriceType.Free,EventCategory=EventCategory.Fashion,},

            };
        }
    }
}

