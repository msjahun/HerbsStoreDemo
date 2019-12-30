using Microsoft.EntityFrameworkCore.Migrations;

namespace HerbsStore.Migrations
{
    public partial class addedQuantityandOtherProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cvv",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpiryDate",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOnCard",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentType",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderProducts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cvv",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NameOnCard",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderProducts");
        }
    }
}
