using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalog.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    PlacePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.PlaceId);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    BillingAddress = table.Column<string>(maxLength: 100, nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    TicketId = table.Column<int>(nullable: false),
                    CreditCardNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    PlaceId1 = table.Column<int>(nullable: false),
                    TicketI = table.Column<int>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventPrice = table.Column<decimal>(nullable: false),
                    EventImageURL = table.Column<string>(nullable: false),
                    EventPriceType = table.Column<int>(nullable: false),
                    EventCategory = table.Column<int>(nullable: false),
                    Ticket = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Catalog_Place_PlaceId1",
                        column: x => x.PlaceId1,
                        principalTable: "Place",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_PlaceId1",
                table: "Catalog",
                column: "PlaceId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropSequence(
                name: "catalog_hilo");
        }
    }
}
