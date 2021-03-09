using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreData.Migrations
{
    public partial class WithIdentity12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationProducts_Locations_LocationID",
                table: "LocationProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationProducts_Locations_LocationID",
                table: "LocationProducts",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationProducts_Locations_LocationID",
                table: "LocationProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationProducts_Locations_LocationID",
                table: "LocationProducts",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
