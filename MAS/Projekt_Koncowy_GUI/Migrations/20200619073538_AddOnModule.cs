using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class AddOnModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndpointDevices_CommunicationModule_CommunicationModuleImei",
                table: "EndpointDevices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunicationModule",
                table: "CommunicationModule");

            migrationBuilder.RenameTable(
                name: "CommunicationModule",
                newName: "CommunicationModules");

            migrationBuilder.RenameIndex(
                name: "IX_CommunicationModule_IMEI",
                table: "CommunicationModules",
                newName: "IX_CommunicationModules_IMEI");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunicationModules",
                table: "CommunicationModules",
                column: "IMEI");

            migrationBuilder.CreateTable(
                name: "AddOnModules",
                columns: table => new
                {
                    AddOnModuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOnModules", x => x.AddOnModuleId);
                });

            migrationBuilder.CreateTable(
                name: "BluetoothModules",
                columns: table => new
                {
                    BluetoothModuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransmisionVersion = table.Column<string>(nullable: true),
                    AddOnModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BluetoothModules", x => x.BluetoothModuleId);
                    table.ForeignKey(
                        name: "FK_BluetoothModules_AddOnModules_AddOnModuleId",
                        column: x => x.AddOnModuleId,
                        principalTable: "AddOnModules",
                        principalColumn: "AddOnModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GPSModules",
                columns: table => new
                {
                    GPSModuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddOnModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPSModules", x => x.GPSModuleId);
                    table.ForeignKey(
                        name: "FK_GPSModules_AddOnModules_AddOnModuleId",
                        column: x => x.AddOnModuleId,
                        principalTable: "AddOnModules",
                        principalColumn: "AddOnModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupportedSattelites",
                columns: table => new
                {
                    SupportedSattelitesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GPSModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportedSattelites", x => x.SupportedSattelitesId);
                    table.ForeignKey(
                        name: "FK_SupportedSattelites_GPSModules_GPSModuleId",
                        column: x => x.GPSModuleId,
                        principalTable: "GPSModules",
                        principalColumn: "GPSModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 21, 9, 35, 38, 474, DateTimeKind.Local).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 20, 9, 35, 38, 477, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.CreateIndex(
                name: "IX_BluetoothModules_AddOnModuleId",
                table: "BluetoothModules",
                column: "AddOnModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_GPSModules_AddOnModuleId",
                table: "GPSModules",
                column: "AddOnModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportedSattelites_GPSModuleId",
                table: "SupportedSattelites",
                column: "GPSModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_EndpointDevices_CommunicationModules_CommunicationModuleImei",
                table: "EndpointDevices",
                column: "CommunicationModuleImei",
                principalTable: "CommunicationModules",
                principalColumn: "IMEI",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndpointDevices_CommunicationModules_CommunicationModuleImei",
                table: "EndpointDevices");

            migrationBuilder.DropTable(
                name: "BluetoothModules");

            migrationBuilder.DropTable(
                name: "SupportedSattelites");

            migrationBuilder.DropTable(
                name: "GPSModules");

            migrationBuilder.DropTable(
                name: "AddOnModules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunicationModules",
                table: "CommunicationModules");

            migrationBuilder.RenameTable(
                name: "CommunicationModules",
                newName: "CommunicationModule");

            migrationBuilder.RenameIndex(
                name: "IX_CommunicationModules_IMEI",
                table: "CommunicationModule",
                newName: "IX_CommunicationModule_IMEI");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunicationModule",
                table: "CommunicationModule",
                column: "IMEI");

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 21, 9, 26, 15, 858, DateTimeKind.Local).AddTicks(4861));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 20, 9, 26, 15, 861, DateTimeKind.Local).AddTicks(365));

            migrationBuilder.AddForeignKey(
                name: "FK_EndpointDevices_CommunicationModule_CommunicationModuleImei",
                table: "EndpointDevices",
                column: "CommunicationModuleImei",
                principalTable: "CommunicationModule",
                principalColumn: "IMEI",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
