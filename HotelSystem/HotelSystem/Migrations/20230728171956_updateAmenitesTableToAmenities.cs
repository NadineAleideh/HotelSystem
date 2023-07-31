using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSystem.Migrations
{
    /// <inheritdoc />
    public partial class updateAmenitesTableToAmenities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Amenites_AmenityId",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amenites",
                table: "Amenites");

            migrationBuilder.RenameTable(
                name: "Amenites",
                newName: "Amenities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amenities",
                table: "Amenities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenityId",
                table: "RoomAmenities",
                column: "AmenityId",
                principalTable: "Amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenityId",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amenities",
                table: "Amenities");

            migrationBuilder.RenameTable(
                name: "Amenities",
                newName: "Amenites");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amenites",
                table: "Amenites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Amenites_AmenityId",
                table: "RoomAmenities",
                column: "AmenityId",
                principalTable: "Amenites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
