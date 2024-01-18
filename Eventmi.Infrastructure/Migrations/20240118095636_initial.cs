using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventmi.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the town")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "Name of the town")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                },
                comment: "Town of the address");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier of address")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Sreet of the place"),
                    TownId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of town")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Address of the event");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the event")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the event"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start of the event"),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "End of the event"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the event"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date deleted"),
                    PlaceId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the place")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Addresses_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Event");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_TownId",
                table: "Addresses",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PlaceId",
                table: "Events",
                column: "PlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Towns");
        }
    }
}
