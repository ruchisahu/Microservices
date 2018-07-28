﻿using EventCatalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalog.Data
{
    public class EventCatalogContext : DbContext
    {
        public EventCatalogContext(DbContextOptions options) :
            base(options)
        { }


        public DbSet<Place> Places { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Eventcatalog> Eventcatalogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Place>(ConfigurePlace);
            builder.Entity<Ticket>(ConfigureTicket);
            builder.Entity<User>(ConfigureUser);
            builder.Entity<Eventcatalog>(ConfigureEventcatalog);
        }

        private void ConfigureEventcatalog(EntityTypeBuilder<Eventcatalog> builder)
        {
            builder.ToTable("Catalog");
            builder.Property(c => c.EventId)
                .ForSqlServerUseSequenceHiLo("catalog_hilo")
                .IsRequired();
            builder.Property(c => c.EventName)
                .IsRequired();
            builder.Property(c => c.Description)
                 .IsRequired();
            builder.Property(c => c.Location)
                .IsRequired();

            builder.HasOne(c => c.Place)
                .WithMany()
                .HasForeignKey(c => c.PlaceId1);

            builder.Property(c => c.Ticket)
               .IsRequired();
            builder.Property(c => c.EventDate)
                .IsRequired();
            builder.Property(c => c.EventPrice)
                .IsRequired();
            builder.Property(c => c.EventImageURL)
                .IsRequired();
            builder.Property(c => c.EventPriceType)
                .IsRequired();
            builder.Property(c => c.EventCategory)
                .IsRequired();

        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
             builder.ToTable("User");
            builder.Property(c => c.UserId)
                .ForSqlServerUseSequenceHiLo("catalog_hilo")
                .IsRequired();
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Email)
              .IsRequired()
              .HasMaxLength(50);
            builder.Property(c => c.Password)
              .IsRequired()
              .HasMaxLength(50);
            builder.Property(c => c.BillingAddress)
              .IsRequired()
              .HasMaxLength(100);
            builder.Property(c => c.EventId)
              .IsRequired();
            builder.Property(c => c.TicketId)
                   .IsRequired();
            builder.Property(c => c.CreditCardNo)
              .IsRequired();
              

        }

        private void ConfigureTicket(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Ticket");
            builder.Property(c => c.TicketId)
              .IsRequired();
           



        }

        private void ConfigurePlace(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("Place");
            builder.Property(c => c.PlaceId)
              .IsRequired();
            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.PlacePrice)
              .IsRequired();
              
        }
    }
}
