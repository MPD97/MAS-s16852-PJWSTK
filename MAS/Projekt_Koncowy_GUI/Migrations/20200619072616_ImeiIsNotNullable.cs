using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class ImeiIsNotNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndpointDevices_CommunicationModule_CommunicationModuleImei",
                table: "EndpointDevices");

            migrationBuilder.AlterColumn<string>(
                name: "CommunicationModuleImei",
                table: "EndpointDevices",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndpointDevices_CommunicationModule_CommunicationModuleImei",
                table: "EndpointDevices");

            migrationBuilder.AlterColumn<string>(
                name: "CommunicationModuleImei",
                table: "EndpointDevices",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 21, 9, 25, 51, 325, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 20, 9, 25, 51, 328, DateTimeKind.Local).AddTicks(864));

            migrationBuilder.AddForeignKey(
                name: "FK_EndpointDevices_CommunicationModule_CommunicationModuleImei",
                table: "EndpointDevices",
                column: "CommunicationModuleImei",
                principalTable: "CommunicationModule",
                principalColumn: "IMEI",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
