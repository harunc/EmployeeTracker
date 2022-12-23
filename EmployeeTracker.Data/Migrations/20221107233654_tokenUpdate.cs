using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeTracker.Data.Migrations
{
    public partial class tokenUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAndMachines",
                table: "EmployeeAndMachines");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Employees",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Employees",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAndMachines",
                table: "EmployeeAndMachines",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAndMachines_EmployeeId",
                table: "EmployeeAndMachines",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAndMachines",
                table: "EmployeeAndMachines");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAndMachines_EmployeeId",
                table: "EmployeeAndMachines");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAndMachines",
                table: "EmployeeAndMachines",
                columns: new[] { "EmployeeId", "MachineId" });
        }
    }
}
