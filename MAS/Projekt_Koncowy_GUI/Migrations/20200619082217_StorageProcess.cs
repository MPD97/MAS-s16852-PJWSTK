using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class StorageProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaticProperties",
                columns: table => new
                {
                    StaticPropertiesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticProperties", x => x.StaticPropertiesId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    AreaInSquareMeters = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageProcesses",
                columns: table => new
                {
                    StorageProcessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlacementDate = table.Column<DateTime>(nullable: false),
                    FromReturn = table.Column<bool>(nullable: false),
                    EndpointDeviceId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageProcesses", x => x.StorageProcessId);
                    table.ForeignKey(
                        name: "FK_StorageProcesses_EndpointDevices_EndpointDeviceId",
                        column: x => x.EndpointDeviceId,
                        principalTable: "EndpointDevices",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageProcesses_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeServicemans",
                columns: table => new
                {
                    EmployeeServicemanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Specialization = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeServicemans", x => x.EmployeeServicemanId);
                    table.ForeignKey(
                        name: "FK_EmployeeServicemans_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStorekeepers",
                columns: table => new
                {
                    EmployeeStorekeeperId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    ForkliftLicense = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStorekeepers", x => x.EmployeeStorekeeperId);
                    table.ForeignKey(
                        name: "FK_EmployeeStorekeepers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 21, 10, 22, 16, 795, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 20, 10, 22, 16, 797, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WarehouseId",
                table: "Employees",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeServicemans_EmployeeId",
                table: "EmployeeServicemans",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeStorekeepers_EmployeeId",
                table: "EmployeeStorekeepers",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StorageProcesses_EndpointDeviceId",
                table: "StorageProcesses",
                column: "EndpointDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageProcesses_WarehouseId",
                table: "StorageProcesses",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeServicemans");

            migrationBuilder.DropTable(
                name: "EmployeeStorekeepers");

            migrationBuilder.DropTable(
                name: "StaticProperties");

            migrationBuilder.DropTable(
                name: "StorageProcesses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 21, 9, 53, 38, 314, DateTimeKind.Local).AddTicks(9695));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 20, 9, 53, 38, 317, DateTimeKind.Local).AddTicks(3642));
        }
    }
}
