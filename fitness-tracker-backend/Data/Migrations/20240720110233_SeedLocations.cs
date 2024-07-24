using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fitness_tracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Workouts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_LocationId",
                table: "Workouts",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Locations_LocationId",
                table: "Workouts",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Locations_LocationId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_LocationId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Workouts");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Workouts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
