using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class FixPrzedOddaniemProjektu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_EndpointDevices_EndpointDeviceIdentifier",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_UserNormals_UserId",
                table: "UserNormals");

            migrationBuilder.DropIndex(
                name: "IX_UserAdministrators_UserId",
                table: "UserAdministrators");

            migrationBuilder.DropIndex(
                name: "IX_PartialLicenses_LicenseId",
                table: "PartialLicenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_EndpointDeviceIdentifier",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_fullLicenses_LicenseId",
                table: "fullLicenses");

            migrationBuilder.DropColumn(
                name: "EndpointDeviceIdentifier",
                table: "Licenses");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserNormals",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserAdministrators",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EndpointDeviceId",
                table: "Licenses",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_PartialLicenses_LicenseId",
                table: "PartialLicenses",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_EndpointDeviceId",
                table: "Licenses",
                column: "EndpointDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_fullLicenses_LicenseId",
                table: "fullLicenses",
                column: "LicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_EndpointDevices_EndpointDeviceId",
                table: "Licenses",
                column: "EndpointDeviceId",
                principalTable: "EndpointDevices",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_EndpointDevices_EndpointDeviceId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_UserNormals_UserId",
                table: "UserNormals");

            migrationBuilder.DropIndex(
                name: "IX_UserAdministrators_UserId",
                table: "UserAdministrators");

            migrationBuilder.DropIndex(
                name: "IX_PartialLicenses_LicenseId",
                table: "PartialLicenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_EndpointDeviceId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_fullLicenses_LicenseId",
                table: "fullLicenses");

            migrationBuilder.DropColumn(
                name: "EndpointDeviceId",
                table: "Licenses");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserNormals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserAdministrators",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EndpointDeviceIdentifier",
                table: "Licenses",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 10,
                column: "DateOfProduction",
                value: new DateTime(2020, 3, 21, 11, 57, 2, 577, DateTimeKind.Local).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "EndpointDevices",
                keyColumn: "Identifier",
                keyValue: 15,
                column: "DateOfProduction",
                value: new DateTime(2020, 4, 20, 11, 57, 2, 580, DateTimeKind.Local).AddTicks(3744));

            migrationBuilder.CreateIndex(
                name: "IX_UserNormals_UserId",
                table: "UserNormals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdministrators_UserId",
                table: "UserAdministrators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PartialLicenses_LicenseId",
                table: "PartialLicenses",
                column: "LicenseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_EndpointDeviceIdentifier",
                table: "Licenses",
                column: "EndpointDeviceIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_fullLicenses_LicenseId",
                table: "fullLicenses",
                column: "LicenseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_EndpointDevices_EndpointDeviceIdentifier",
                table: "Licenses",
                column: "EndpointDeviceIdentifier",
                principalTable: "EndpointDevices",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
