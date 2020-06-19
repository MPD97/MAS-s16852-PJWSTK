using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Licenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "LicenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAdministrators",
                columns: table => new
                {
                    UserAdministratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdministrators", x => x.UserAdministratorId);
                    table.ForeignKey(
                        name: "FK_UserAdministrators_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNormals",
                columns: table => new
                {
                    UserNormalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNormals", x => x.UserNormalId);
                    table.ForeignKey(
                        name: "FK_UserNormals_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_User_LicenseId",
                table: "User",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdministrators_UserId",
                table: "UserAdministrators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNormals_UserId",
                table: "UserNormals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAdministrators");

            migrationBuilder.DropTable(
                name: "UserNormals");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 21, 10, 52, 28, 147, DateTimeKind.Local).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 20, 10, 52, 28, 150, DateTimeKind.Local).AddTicks(4621));
        }
    }
}
