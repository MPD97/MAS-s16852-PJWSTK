using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class FixPrzedOddaniemProjektu2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserNormals_UserId",
                table: "UserNormals");

            migrationBuilder.DropIndex(
                name: "IX_UserAdministrators_UserId",
                table: "UserAdministrators");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserNormals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserAdministrators",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 23, 12, 59, 16, 241, DateTimeKind.Local).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 22, 12, 59, 16, 245, DateTimeKind.Local).AddTicks(9201));

            migrationBuilder.CreateIndex(
                name: "IX_UserNormals_UserId",
                table: "UserNormals",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAdministrators_UserId",
                table: "UserAdministrators",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserNormals_UserId",
                table: "UserNormals");

            migrationBuilder.DropIndex(
                name: "IX_UserAdministrators_UserId",
                table: "UserAdministrators");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserNormals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserAdministrators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 23, 12, 50, 16, 65, DateTimeKind.Local).AddTicks(5682));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 22, 12, 50, 16, 70, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.CreateIndex(
                name: "IX_UserNormals_UserId",
                table: "UserNormals",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdministrators_UserId",
                table: "UserAdministrators",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
