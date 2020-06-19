using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class ImeiAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CommunicationModule",
                columns: new[] { "IMEI", "Frequency", "Model", "SerialNumber" },
                values: new object[] { "432234543231284", 5500, "X425", 123536190258L });

            migrationBuilder.InsertData(
                table: "CommunicationModule",
                columns: new[] { "IMEI", "Frequency", "Model", "SerialNumber" },
                values: new object[] { "999683672983858", 5500, "WW849", 643643634634L });

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                columns: new[] { "CommunicationModuleImei", "DateOfProduction" },
                values: new object[] { "432234543231284", new DateTime(2020, 3, 21, 9, 25, 51, 325, DateTimeKind.Local).AddTicks(4977) });

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                columns: new[] { "CommunicationModuleImei", "DateOfProduction" },
                values: new object[] { "999683672983858", new DateTime(2020, 4, 20, 9, 25, 51, 328, DateTimeKind.Local).AddTicks(864) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommunicationModule",
                keyColumn: "IMEI",
                keyValue: "432234543231284");

            migrationBuilder.DeleteData(
                table: "CommunicationModule",
                keyColumn: "IMEI",
                keyValue: "999683672983858");

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "CommunicationModuleImei",
                value: null);

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "CommunicationModuleImei",
                value: null);

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                columns: new[] { "CommunicationModuleImei", "DateOfProduction" },
                values: new object[] { null, new DateTime(2020, 3, 21, 9, 21, 29, 459, DateTimeKind.Local).AddTicks(5846) });

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                columns: new[] { "CommunicationModuleImei", "DateOfProduction" },
                values: new object[] { null, new DateTime(2020, 4, 20, 9, 21, 29, 462, DateTimeKind.Local).AddTicks(8504) });
        }
    }
}
