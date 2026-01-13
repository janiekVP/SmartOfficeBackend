using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Floorplan.Migrations
{
    /// <inheritdoc />
    public partial class AddFloorplanImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Floorplans",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageContentType",
                table: "Floorplans",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Floorplans");

            migrationBuilder.DropColumn(
                name: "ImageContentType",
                table: "Floorplans");
        }
    }
}
