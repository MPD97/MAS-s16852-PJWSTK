using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class AddOnModuleMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EndpointDeviceId",
                table: "AddOnModules",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_AddOnModules_EndpointDeviceId",
                table: "AddOnModules",
                column: "EndpointDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddOnModules_EndpointDevices_EndpointDeviceId",
                table: "AddOnModules",
                column: "EndpointDeviceId",
                principalTable: "EndpointDevices",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddOnModules_EndpointDevices_EndpointDeviceId",
                table: "AddOnModules");

            migrationBuilder.DropIndex(
                name: "IX_AddOnModules_EndpointDeviceId",
                table: "AddOnModules");

            migrationBuilder.DropColumn(
                name: "EndpointDeviceId",
                table: "AddOnModules");

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
        }
    }
}
