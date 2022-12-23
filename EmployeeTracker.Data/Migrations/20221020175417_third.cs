using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeTracker.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MachineOwnedId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MachineOwnedId",
                table: "Employees",
                column: "MachineOwnedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Machines_MachineOwnedId",
                table: "Employees",
                column: "MachineOwnedId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Machines_MachineOwnedId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_MachineOwnedId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MachineOwnedId",
                table: "Employees");
        }
    }
}
