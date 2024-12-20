using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalendarViewModelId",
                table: "Shifts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalendarViewModelId",
                table: "Assistants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalendarViewModelId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "appointmentInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssistantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssistantTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeSlot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointmentInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "calendarViewModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calendarViewModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_CalendarViewModelId",
                table: "Shifts",
                column: "CalendarViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Assistants_CalendarViewModelId",
                table: "Assistants",
                column: "CalendarViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CalendarViewModelId",
                table: "Appointments",
                column: "CalendarViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_calendarViewModels_CalendarViewModelId",
                table: "Appointments",
                column: "CalendarViewModelId",
                principalTable: "calendarViewModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assistants_calendarViewModels_CalendarViewModelId",
                table: "Assistants",
                column: "CalendarViewModelId",
                principalTable: "calendarViewModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_calendarViewModels_CalendarViewModelId",
                table: "Shifts",
                column: "CalendarViewModelId",
                principalTable: "calendarViewModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_calendarViewModels_CalendarViewModelId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assistants_calendarViewModels_CalendarViewModelId",
                table: "Assistants");

            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_calendarViewModels_CalendarViewModelId",
                table: "Shifts");

            migrationBuilder.DropTable(
                name: "appointmentInfos");

            migrationBuilder.DropTable(
                name: "calendarViewModels");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_CalendarViewModelId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Assistants_CalendarViewModelId",
                table: "Assistants");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CalendarViewModelId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CalendarViewModelId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "CalendarViewModelId",
                table: "Assistants");

            migrationBuilder.DropColumn(
                name: "CalendarViewModelId",
                table: "Appointments");
        }
    }
}
