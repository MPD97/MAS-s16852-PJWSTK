using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Koncowy_GUI.Migrations
{
    public partial class AddedAvailableAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Component_ComponentIdentifier",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_EndpointDevice_EndpointDeviceIdentifier",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Replacement_Component_BaseId",
                table: "Replacement");

            migrationBuilder.DropForeignKey(
                name: "FK_Replacement_Component_ReplacedById",
                table: "Replacement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Replacement",
                table: "Replacement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EndpointDevice",
                table: "EndpointDevice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Component",
                table: "Component");

            migrationBuilder.RenameTable(
                name: "Replacement",
                newName: "Replacements");

            migrationBuilder.RenameTable(
                name: "Equipment",
                newName: "Equipments");

            migrationBuilder.RenameTable(
                name: "EndpointDevice",
                newName: "EndpointDevices");

            migrationBuilder.RenameTable(
                name: "Component",
                newName: "Components");

            migrationBuilder.RenameIndex(
                name: "IX_Replacement_ReplacedById",
                table: "Replacements",
                newName: "IX_Replacements_ReplacedById");

            migrationBuilder.RenameIndex(
                name: "IX_Replacement_BaseId",
                table: "Replacements",
                newName: "IX_Replacements_BaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_EndpointDeviceIdentifier",
                table: "Equipments",
                newName: "IX_Equipments_EndpointDeviceIdentifier");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_ComponentIdentifier",
                table: "Equipments",
                newName: "IX_Equipments_ComponentIdentifier");

            migrationBuilder.AddColumn<int>(
                name: "AvailableAmount",
                table: "Components",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Replacements",
                table: "Replacements",
                column: "ReplacementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments",
                column: "EquipmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EndpointDevices",
                table: "EndpointDevices",
                column: "Identifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Components",
                table: "Components",
                column: "Identifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Components_ComponentIdentifier",
                table: "Equipments",
                column: "ComponentIdentifier",
                principalTable: "Components",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_EndpointDevices_EndpointDeviceIdentifier",
                table: "Equipments",
                column: "EndpointDeviceIdentifier",
                principalTable: "EndpointDevices",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Replacements_Components_BaseId",
                table: "Replacements",
                column: "BaseId",
                principalTable: "Components",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Replacements_Components_ReplacedById",
                table: "Replacements",
                column: "ReplacedById",
                principalTable: "Components",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Components_ComponentIdentifier",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_EndpointDevices_EndpointDeviceIdentifier",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Replacements_Components_BaseId",
                table: "Replacements");

            migrationBuilder.DropForeignKey(
                name: "FK_Replacements_Components_ReplacedById",
                table: "Replacements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Replacements",
                table: "Replacements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EndpointDevices",
                table: "EndpointDevices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Components",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "AvailableAmount",
                table: "Components");

            migrationBuilder.RenameTable(
                name: "Replacements",
                newName: "Replacement");

            migrationBuilder.RenameTable(
                name: "Equipments",
                newName: "Equipment");

            migrationBuilder.RenameTable(
                name: "EndpointDevices",
                newName: "EndpointDevice");

            migrationBuilder.RenameTable(
                name: "Components",
                newName: "Component");

            migrationBuilder.RenameIndex(
                name: "IX_Replacements_ReplacedById",
                table: "Replacement",
                newName: "IX_Replacement_ReplacedById");

            migrationBuilder.RenameIndex(
                name: "IX_Replacements_BaseId",
                table: "Replacement",
                newName: "IX_Replacement_BaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_EndpointDeviceIdentifier",
                table: "Equipment",
                newName: "IX_Equipment_EndpointDeviceIdentifier");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_ComponentIdentifier",
                table: "Equipment",
                newName: "IX_Equipment_ComponentIdentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Replacement",
                table: "Replacement",
                column: "ReplacementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment",
                column: "EquipmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EndpointDevice",
                table: "EndpointDevice",
                column: "Identifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Component",
                table: "Component",
                column: "Identifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Component_ComponentIdentifier",
                table: "Equipment",
                column: "ComponentIdentifier",
                principalTable: "Component",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_EndpointDevice_EndpointDeviceIdentifier",
                table: "Equipment",
                column: "EndpointDeviceIdentifier",
                principalTable: "EndpointDevice",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Replacement_Component_BaseId",
                table: "Replacement",
                column: "BaseId",
                principalTable: "Component",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Replacement_Component_ReplacedById",
                table: "Replacement",
                column: "ReplacedById",
                principalTable: "Component",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
