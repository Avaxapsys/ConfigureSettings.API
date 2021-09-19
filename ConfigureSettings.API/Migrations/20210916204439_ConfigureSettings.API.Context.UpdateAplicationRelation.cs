using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfigureSettings.API.Migrations
{
    public partial class ConfigureSettingsAPIContextUpdateAplicationRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Aplications_AplicationId",
                table: "Settings");

            migrationBuilder.AlterColumn<int>(
                name: "AplicationId",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Aplications_AplicationId",
                table: "Settings",
                column: "AplicationId",
                principalTable: "Aplications",
                principalColumn: "AplicationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Aplications_AplicationId",
                table: "Settings");

            migrationBuilder.AlterColumn<int>(
                name: "AplicationId",
                table: "Settings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Aplications_AplicationId",
                table: "Settings",
                column: "AplicationId",
                principalTable: "Aplications",
                principalColumn: "AplicationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
