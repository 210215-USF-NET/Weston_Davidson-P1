using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreData.Migrations
{
    public partial class WithIdentity13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_AppUserFK",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationProducts_Locations_LocationID",
                table: "LocationProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_AppUserFK",
                table: "Customers",
                column: "AppUserFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationProducts_Locations_LocationID",
                table: "LocationProducts",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_AppUserFK",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationProducts_Locations_LocationID",
                table: "LocationProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_AppUserFK",
                table: "Customers",
                column: "AppUserFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationProducts_Locations_LocationID",
                table: "LocationProducts",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
