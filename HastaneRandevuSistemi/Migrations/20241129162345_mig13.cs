using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Emergencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Emergencies_DepartmentId",
                table: "Emergencies",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emergencies_Departments_DepartmentId",
                table: "Emergencies",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emergencies_Departments_DepartmentId",
                table: "Emergencies");

            migrationBuilder.DropIndex(
                name: "IX_Emergencies_DepartmentId",
                table: "Emergencies");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Emergencies");
        }
    }
}
