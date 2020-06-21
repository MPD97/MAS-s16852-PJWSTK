using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class communicationModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommunicationModuleImei",
                table: "EndpointDevices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommunicationModule",
                columns: table => new
                {
                    IMEI = table.Column<string>(nullable: false),
                    Frequency = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationModule", x => x.IMEI);
                });

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 21, 9, 21, 29, 459, DateTimeKind.Local).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 20, 9, 21, 29, 462, DateTimeKind.Local).AddTicks(8504));

            migrationBuilder.CreateIndex(
                name: "IX_EndpointDevices_CommunicationModuleImei",
                table: "EndpointDevices",
                column: "CommunicationModuleImei");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationModule_IMEI",
                table: "CommunicationModule",
                column: "IMEI",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EndpointDevices_CommunicationModule_CommunicationModuleImei",
                table: "EndpointDevices",
                column: "CommunicationModuleImei",
                principalTable: "CommunicationModule",
                principalColumn: "IMEI",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndpointDevices_CommunicationModule_CommunicationModuleImei",
                table: "EndpointDevices");

            migrationBuilder.DropTable(
                name: "CommunicationModule");

            migrationBuilder.DropIndex(
                name: "IX_EndpointDevices_CommunicationModuleImei",
                table: "EndpointDevices");

            migrationBuilder.DropColumn(
                name: "CommunicationModuleImei",
                table: "EndpointDevices");

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 11, 12, 38, 1, 562, DateTimeKind.Local).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 10, 12, 38, 1, 566, DateTimeKind.Local).AddTicks(2214));
        }
    }
}
