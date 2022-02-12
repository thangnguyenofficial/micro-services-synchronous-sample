using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThangNguyen.GlobalTicket.EventCatalog.Migrations
{
    public partial class CreateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"), null, "Concerts" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"), null, "Musicals" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea316"), null, "Plays" });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea317"), "John Egbert", new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"), new DateTime(2022, 5, 9, 7, 46, 9, 88, DateTimeKind.Local).AddTicks(7418), "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.", "/img/banjo.jpg", "John Egbert Live", 65 });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea319"), "Michael Johnson", new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"), new DateTime(2022, 8, 9, 7, 46, 9, 89, DateTimeKind.Local).AddTicks(5478), "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?", "/img/michael.jpg", "The State of Affairs: Michael Live!", 85 });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea318"), "Nick Sailor", new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"), new DateTime(2022, 7, 9, 7, 46, 9, 89, DateTimeKind.Local).AddTicks(5564), "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.", "/img/musical.jpg", "To the Moon and Back", 135 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea316"));

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea317"));

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea318"));

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea319"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"));
        }
    }
}
