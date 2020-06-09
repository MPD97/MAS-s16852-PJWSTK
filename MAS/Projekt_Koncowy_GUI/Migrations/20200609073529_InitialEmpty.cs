using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class InitialEmpty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    Identifier = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "EndpointDevice",
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
                    table.PrimaryKey("PK_EndpointDevice", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Replacement",
                columns: table => new
                {
                    ReplacementId = table.Column<string>(nullable: false),
                    BaseId = table.Column<string>(nullable: true),
                    ReplacedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replacement", x => x.ReplacementId);
                    table.ForeignKey(
                        name: "FK_Replacement_Component_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Component",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Replacement_Component_ReplacedById",
                        column: x => x.ReplacedById,
                        principalTable: "Component",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentIdentifier = table.Column<string>(nullable: true),
                    EndpointDeviceIdentifier = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_Equipment_Component_ComponentIdentifier",
                        column: x => x.ComponentIdentifier,
                        principalTable: "Component",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_EndpointDevice_EndpointDeviceIdentifier",
                        column: x => x.EndpointDeviceIdentifier,
                        principalTable: "EndpointDevice",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ComponentIdentifier",
                table: "Equipment",
                column: "ComponentIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EndpointDeviceIdentifier",
                table: "Equipment",
                column: "EndpointDeviceIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Replacement_BaseId",
                table: "Replacement",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Replacement_ReplacedById",
                table: "Replacement",
                column: "ReplacedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Replacement");

            migrationBuilder.DropTable(
                name: "EndpointDevice");

            migrationBuilder.DropTable(
                name: "Component");
        }
    }
}
