using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepAsInsId",
                table: "Shifts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepAsInsId",
                table: "Instructors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentPatient",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepAsInsId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepAsInsId",
                table: "Assistants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DepAsInss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepAsInss", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_DepAsInsId",
                table: "Shifts",
                column: "DepAsInsId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepAsInsId",
                table: "Instructors",
                column: "DepAsInsId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepAsInsId",
                table: "Departments",
                column: "DepAsInsId");

            migrationBuilder.CreateIndex(
                name: "IX_Assistants_DepAsInsId",
                table: "Assistants",
                column: "DepAsInsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assistants_DepAsInss_DepAsInsId",
                table: "Assistants",
                column: "DepAsInsId",
                principalTable: "DepAsInss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_DepAsInss_DepAsInsId",
                table: "Departments",
                column: "DepAsInsId",
                principalTable: "DepAsInss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_DepAsInss_DepAsInsId",
                table: "Instructors",
                column: "DepAsInsId",
                principalTable: "DepAsInss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_DepAsInss_DepAsInsId",
                table: "Shifts",
                column: "DepAsInsId",
                principalTable: "DepAsInss",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assistants_DepAsInss_DepAsInsId",
                table: "Assistants");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_DepAsInss_DepAsInsId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_DepAsInss_DepAsInsId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_DepAsInss_DepAsInsId",
                table: "Shifts");

            migrationBuilder.DropTable(
                name: "DepAsInss");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_DepAsInsId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_DepAsInsId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepAsInsId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Assistants_DepAsInsId",
                table: "Assistants");

            migrationBuilder.DropColumn(
                name: "DepAsInsId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "DepAsInsId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "CurrentPatient",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepAsInsId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepAsInsId",
                table: "Assistants");
        }
    }
}
