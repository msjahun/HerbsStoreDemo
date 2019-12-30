using Microsoft.EntityFrameworkCore.Migrations;

namespace HerbsStore.Migrations
{
    public partial class updatedDataTypeOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "OrderStatus",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
