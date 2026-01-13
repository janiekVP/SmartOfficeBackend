using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SensorData.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensorData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    POISensorId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Battery = table.Column<byte>(type: "smallint", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    Noise = table.Column<int>(type: "integer", nullable: false),
                    Light = table.Column<int>(type: "integer", nullable: false),
                    Co2 = table.Column<int>(type: "integer", nullable: false),
                    LastComDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_LastComDate",
                table: "SensorData",
                column: "LastComDate");

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_POISensorId",
                table: "SensorData",
                column: "POISensorId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_POISensorId_LastComDate",
                table: "SensorData",
                columns: new[] { "POISensorId", "LastComDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorData");
        }
    }
}
