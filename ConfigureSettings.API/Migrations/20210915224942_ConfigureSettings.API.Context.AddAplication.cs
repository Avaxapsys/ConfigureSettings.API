using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfigureSettings.API.Migrations
{
    public partial class ConfigureSettingsAPIContextAddAplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Settings",
                newName: "SettingId");

            migrationBuilder.AddColumn<int>(
                name: "AplicationId",
                table: "Settings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Aplications",
                columns: table => new
                {
                    AplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplications", x => x.AplicationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_AplicationId",
                table: "Settings",
                column: "AplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Aplications_AplicationId",
                table: "Settings",
                column: "AplicationId",
                principalTable: "Aplications",
                principalColumn: "AplicationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Aplications_AplicationId",
                table: "Settings");

            migrationBuilder.DropTable(
                name: "Aplications");

            migrationBuilder.DropIndex(
                name: "IX_Settings_AplicationId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AplicationId",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "SettingId",
                table: "Settings",
                newName: "Id");
        }
    }
}
