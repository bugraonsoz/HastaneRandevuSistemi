using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalendarViewModelId",
                table: "Instructors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CalendarViewModelId",
                table: "Instructors",
                column: "CalendarViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_calendarViewModels_CalendarViewModelId",
                table: "Instructors",
                column: "CalendarViewModelId",
                principalTable: "calendarViewModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_calendarViewModels_CalendarViewModelId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_CalendarViewModelId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "CalendarViewModelId",
                table: "Instructors");
        }
    }
}
