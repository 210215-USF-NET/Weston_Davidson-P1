using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreData.Migrations
{
    public partial class WithIdentity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "AppUserFK",
                table: "Customers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AppUserFK",
                table: "Customers",
                column: "AppUserFK",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_AppUserFK",
                table: "Customers",
                column: "AppUserFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_AppUserFK",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AppUserFK",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AppUserFK",
                table: "Customers");

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
    }
}
