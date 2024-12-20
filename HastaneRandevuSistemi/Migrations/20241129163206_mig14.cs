using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emergencies_Departments_DepartmentID",
                table: "Emergencies");

            migrationBuilder.DropIndex(
                name: "IX_Emergencies_DepartmentID",
                table: "Emergencies");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentID",
                table: "Emergencies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DepartmentID",
                table: "Emergencies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emergencies_DepartmentID",
                table: "Emergencies",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Emergencies_Departments_DepartmentID",
                table: "Emergencies",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
