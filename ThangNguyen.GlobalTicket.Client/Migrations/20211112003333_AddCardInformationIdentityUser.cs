using Microsoft.EntityFrameworkCore.Migrations;

namespace ThangNguyen.GlobalTicket.Client.Migrations
{
    public partial class AddCardInformationIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardHolderName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CardType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Expiration",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardHolderName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CardType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Expiration",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurityNumber",
                table: "AspNetUsers");
        }
    }
}
