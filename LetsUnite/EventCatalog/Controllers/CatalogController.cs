﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalog.Data;
using EventCatalog.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCatalog.Controllers
{
    [Produces("application/json")]
    [Route("api/Catalog")]
    public class CatalogController : Controller
    {
        private readonly EventCatalogContext _catalogContext;

        public CatalogController(EventCatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Catalogs()
        {
            var items = await _catalogContext.Eventcatalogs.ToListAsync();
            //   var items = 6;
            return Ok(items);


        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Users()
        {
            var items = await _catalogContext.Users.ToListAsync();
            //   var items = 6;
            return Ok(items);


        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Tickets()
        {
            var items = await _catalogContext.Tickets.ToListAsync();
            //   var items = 6;
            return Ok(items);


        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Places()
        {
            var items = await _catalogContext.Places.ToListAsync();
            //   var items = 6;
            return Ok(items);


        }

        [HttpPost]
        [Route("Ticket")]
        public async Task<IActionResult> CreateTicketAsync([FromBody] Ticket Ticket)
        {
            var item = new Ticket
            {
                TicketId = Ticket.TicketId,
                

            };
            _catalogContext.Tickets.Add(item);
            await _catalogContext.SaveChangesAsync();

            return Ok(item);
        }

        [HttpPost]
        [Route("Event")]
        public async Task<IActionResult> CreateEventAsync([FromBody] Eventcatalog Event)
        {
            var item = new Eventcatalog
            {
                EventId = Event.EventId,
                EventName = Event.EventName,
                Description = Event.Description,
               
                EventDate=Event.EventDate,
                EventPrice=Event.EventPrice,
                EventImageURL=Event.EventImageURL,
                EventPriceType=Event.EventPriceType,
                EventCategory=Event.EventCategory,
                TicketId=Event.TicketId

            };
            _catalogContext.Eventcatalogs.Add(item);
            await _catalogContext.SaveChangesAsync();

            return Ok(item);
        }
    }
}
            
           
           
           
