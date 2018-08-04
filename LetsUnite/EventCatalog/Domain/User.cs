﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalog.Domain
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string BillingAddress { get; set; }
                
        public int TicketId { get; set; }
        public int CreditCardNo { get; set; }

            [ForeignKey("EventId")]
        public int EventId { get; set; }
        public Eventcatalog Eventcatalog { get; set; }

        
         }
}
