using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeTracker.Data.Migrations
{
    public partial class sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAndMachines",
                table: "EmployeeAndMachines");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAndMachines_EmployeeId",
                table: "EmployeeAndMachines");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAndMachines",
                table: "EmployeeAndMachines",
                columns: new[] { "EmployeeId", "MachineId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAndMachines",
                table: "EmployeeAndMachines");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAndMachines",
                table: "EmployeeAndMachines",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAndMachines_EmployeeId",
                table: "EmployeeAndMachines",
                column: "EmployeeId");
        }
    }
}
