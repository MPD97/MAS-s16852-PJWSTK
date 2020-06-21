using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class AIO2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndpointDevices_CommunicationModules_CommunicationModuleImei",
                table: "EndpointDevices");

            migrationBuilder.DropIndex(
                name: "IX_EndpointDevices_CommunicationModuleImei",
                table: "EndpointDevices");

            migrationBuilder.DropColumn(
                name: "CommunicationModuleImei",
                table: "EndpointDevices");

            migrationBuilder.AddColumn<int>(
                name: "EndpointDeviceId",
                table: "CommunicationModules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CommunicationModules",
                keyColumn: "IMEI",
                keyValue: "432234543231284",
                column: "EndpointDeviceId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "CommunicationModules",
                keyColumn: "IMEI",
                keyValue: "999683672983858",
                column: "EndpointDeviceId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 21, 10, 29, 43, 57, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 20, 10, 29, 43, 59, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationModules_EndpointDeviceId",
                table: "CommunicationModules",
                column: "EndpointDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationModules_EndpointDevices_EndpointDeviceId",
                table: "CommunicationModules",
                column: "EndpointDeviceId",
                principalTable: "EndpointDevices",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunicationModules_EndpointDevices_EndpointDeviceId",
                table: "CommunicationModules");

            migrationBuilder.DropIndex(
                name: "IX_CommunicationModules_EndpointDeviceId",
                table: "CommunicationModules");

            migrationBuilder.DropColumn(
                name: "EndpointDeviceId",
                table: "CommunicationModules");

            migrationBuilder.AddColumn<string>(
                name: "CommunicationModuleImei",
                table: "EndpointDevices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                columns: new[] { "CommunicationModuleImei", "DateOfProduction" },
                values: new object[] { "432234543231284", new DateTime(2020, 3, 21, 10, 25, 20, 752, DateTimeKind.Local).AddTicks(9947) });

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                columns: new[] { "CommunicationModuleImei", "DateOfProduction" },
                values: new object[] { "999683672983858", new DateTime(2020, 4, 20, 10, 25, 20, 755, DateTimeKind.Local).AddTicks(3538) });

            migrationBuilder.CreateIndex(
                name: "IX_EndpointDevices_CommunicationModuleImei",
                table: "EndpointDevices",
                column: "CommunicationModuleImei");

            migrationBuilder.AddForeignKey(
                name: "FK_EndpointDevices_CommunicationModules_CommunicationModuleImei",
                table: "EndpointDevices",
                column: "CommunicationModuleImei",
                principalTable: "CommunicationModules",
                principalColumn: "IMEI",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
