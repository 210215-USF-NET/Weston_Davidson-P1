using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreData.Migrations
{
    public partial class WithIdentity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerID",
                table: "AspNetUsers",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerID",
                table: "AspNetUsers",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomerID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "AspNetUsers");
        }
    }
}
