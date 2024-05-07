using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTeamManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class EventGameRelationTo1_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Games_EventId",
                table: "Games");

            migrationBuilder.CreateIndex(
                name: "IX_Games_EventId",
                table: "Games",
                column: "EventId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Games_EventId",
                table: "Games");

            migrationBuilder.CreateIndex(
                name: "IX_Games_EventId",
                table: "Games",
                column: "EventId");
        }
    }
}
