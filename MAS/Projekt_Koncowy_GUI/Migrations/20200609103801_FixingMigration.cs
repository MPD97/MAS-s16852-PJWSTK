using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class FixingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Identifier = table.Column<string>(nullable: false),
                    AvailableAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "EndpointDevices",
                columns: table => new
                {
                    Identifier = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfProduction = table.Column<DateTime>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Tested = table.Column<int>(nullable: false),
                    TestResult = table.Column<int>(nullable: false),
                    Gauge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndpointDevices", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Replacements",
                columns: table => new
                {
                    ReplacementId = table.Column<string>(nullable: false),
                    BaseId = table.Column<string>(nullable: true),
                    ReplacedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replacements", x => x.ReplacementId);
                    table.ForeignKey(
                        name: "FK_Replacements_Components_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Components",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Replacements_Components_ReplacedById",
                        column: x => x.ReplacedById,
                        principalTable: "Components",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    ComponentId = table.Column<string>(nullable: true),
                    EndpointDeviceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_Equipments_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipments_EndpointDevices_EndpointDeviceId",
                        column: x => x.EndpointDeviceId,
                        principalTable: "EndpointDevices",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Identifier", "AvailableAmount" },
                values: new object[,]
                {
                    { "AAA-BBB-123", 50 },
                    { "356-RRR-QAZ", 10 },
                    { "MMM-005-550", 3 }
                });

            migrationBuilder.InsertData(
                table: "EndpointDevices",
                columns: new[] { "Identifier", "DateOfProduction", "Gauge", "Model", "TestResult", "Tested" },
                values: new object[,]
                {
                    { 10, new DateTime(2020, 3, 11, 12, 38, 1, 562, DateTimeKind.Local).AddTicks(8929), 2, "Speed 500w", 0, 0 },
                    { 15, new DateTime(2020, 4, 10, 12, 38, 1, 566, DateTimeKind.Local).AddTicks(2214), 2, "Ride Fast 200W", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "EquipmentId", "Amount", "ComponentId", "EndpointDeviceId" },
                values: new object[,]
                {
                    { 1, 5, "356-RRR-QAZ", 10 },
                    { 2, 4, "MMM-005-550", 10 },
                    { 3, 1, "MMM-005-550", 15 },
                    { 4, 6, "AAA-BBB-123", 15 }
                });

            migrationBuilder.InsertData(
                table: "Replacements",
                columns: new[] { "ReplacementId", "BaseId", "ReplacedById" },
                values: new object[] { "REPLACEMENT-ABC123", "MMM-005-550", "AAA-BBB-123" });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ComponentId",
                table: "Equipments",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EndpointDeviceId",
                table: "Equipments",
                column: "EndpointDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Replacements_BaseId",
                table: "Replacements",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Replacements_ReplacedById",
                table: "Replacements",
                column: "ReplacedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Replacements");

            migrationBuilder.DropTable(
                name: "EndpointDevices");

            migrationBuilder.DropTable(
                name: "Components");
        }
    }
}
