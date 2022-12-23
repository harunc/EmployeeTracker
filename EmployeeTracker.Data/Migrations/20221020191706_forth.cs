using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeTracker.Data.Migrations
{
    public partial class forth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "EmployeeAndMachines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    MachineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAndMachines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAndMachines_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAndMachines_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAndMachines_EmployeeId",
                table: "EmployeeAndMachines",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAndMachines_MachineId",
                table: "EmployeeAndMachines",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAndMachines");

            migrationBuilder.AddColumn<int>(
                name: "MachineOwnedId",
                table: "Employees",
                type: "int",
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
    }
}
