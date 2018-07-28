﻿// <auto-generated />
using System;
using EventCatalog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventCatalog.Migrations
{
    [DbContext(typeof(EventCatalogContext))]
    partial class EventCatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:Sequence:.catalog_hilo", "'catalog_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventCatalog.Domain.Eventcatalog", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "catalog_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("EventCategory");

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("EventImageURL")
                        .IsRequired();

                    b.Property<string>("EventName")
                        .IsRequired();

                    b.Property<decimal>("EventPrice");

                    b.Property<int>("EventPriceType");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<int>("PlaceId1");

                    b.Property<int>("Ticket");

                    b.Property<int>("TicketI");

                    b.HasKey("EventId");

                    b.HasIndex("PlaceId1");

                    b.ToTable("Catalog");
                });

            modelBuilder.Entity("EventCatalog.Domain.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("PlacePrice");

                    b.HasKey("PlaceId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("EventCatalog.Domain.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("TicketId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("EventCatalog.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "catalog_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("BillingAddress")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("CreditCardNo");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("EventId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TicketId");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EventCatalog.Domain.Eventcatalog", b =>
                {
                    b.HasOne("EventCatalog.Domain.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId1")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
