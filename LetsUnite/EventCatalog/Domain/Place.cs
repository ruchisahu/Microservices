﻿using System.ComponentModel.DataAnnotations;

namespace EventCatalog.Domain
{
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public decimal PlacePrice { get; set; }

        //   public int EventId { get; set; }
    }
}