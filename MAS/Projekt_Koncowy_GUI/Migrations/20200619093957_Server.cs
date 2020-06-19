using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class Server : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "OperatingSystemId",
                table: "EndpointDevices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EndpointDeviceAddOnModule",
                columns: table => new
                {
                    EndpointDeviceAddOnModuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddOnModuleId = table.Column<int>(nullable: false),
                    EndpointDeviceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndpointDeviceAddOnModule", x => x.EndpointDeviceAddOnModuleId);
                    table.ForeignKey(
                        name: "FK_EndpointDeviceAddOnModule_AddOnModules_AddOnModuleId",
                        column: x => x.AddOnModuleId,
                        principalTable: "AddOnModules",
                        principalColumn: "AddOnModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EndpointDeviceAddOnModule_EndpointDevices_EndpointDeviceId",
                        column: x => x.EndpointDeviceId,
                        principalTable: "EndpointDevices",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    ServerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessorModel = table.Column<string>(nullable: true),
                    ProcessorManufacturer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.ServerId);
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystems",
                columns: table => new
                {
                    OperatingSystemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ServerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystems", x => x.OperatingSystemId);
                    table.ForeignKey(
                        name: "FK_OperatingSystems_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "ServerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServerVMs",
                columns: table => new
                {
                    ServerVMId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VirtualMAC = table.Column<string>(nullable: true),
                    ServerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerVMs", x => x.ServerVMId);
                    table.ForeignKey(
                        name: "FK_ServerVMs_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "ServerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    StorageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerId = table.Column<int>(nullable: false),
                    TakenRamSpace = table.Column<decimal>(nullable: false),
                    RAMSize = table.Column<decimal>(nullable: false),
                    TakenDiskSpace = table.Column<decimal>(nullable: false),
                    DiskSize = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.StorageId);
                    table.ForeignKey(
                        name: "FK_Storages_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "ServerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 21, 11, 39, 57, 483, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 20, 11, 39, 57, 485, DateTimeKind.Local).AddTicks(4879));

            migrationBuilder.CreateIndex(
                name: "IX_EndpointDevices_OperatingSystemId",
                table: "EndpointDevices",
                column: "OperatingSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_EndpointDeviceAddOnModule_AddOnModuleId",
                table: "EndpointDeviceAddOnModule",
                column: "AddOnModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_EndpointDeviceAddOnModule_EndpointDeviceId",
                table: "EndpointDeviceAddOnModule",
                column: "EndpointDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingSystems_ServerId",
                table: "OperatingSystems",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerVMs_ServerId",
                table: "ServerVMs",
                column: "ServerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Storages_ServerId",
                table: "Storages",
                column: "ServerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EndpointDevices_OperatingSystems_OperatingSystemId",
                table: "EndpointDevices",
                column: "OperatingSystemId",
                principalTable: "OperatingSystems",
                principalColumn: "OperatingSystemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndpointDevices_OperatingSystems_OperatingSystemId",
                table: "EndpointDevices");

            migrationBuilder.DropTable(
                name: "EndpointDeviceAddOnModule");

            migrationBuilder.DropTable(
                name: "OperatingSystems");

            migrationBuilder.DropTable(
                name: "ServerVMs");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Servers");

            migrationBuilder.DropIndex(
                name: "IX_EndpointDevices_OperatingSystemId",
                table: "EndpointDevices");

            migrationBuilder.DropColumn(
                name: "OperatingSystemId",
                table: "EndpointDevices");

            migrationBuilder.AddColumn<int>(
                name: "EndpointDeviceId",
                table: "AddOnModules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 21, 11, 12, 27, 659, DateTimeKind.Local).AddTicks(3672));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 20, 11, 12, 27, 661, DateTimeKind.Local).AddTicks(7041));

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
    }
}
