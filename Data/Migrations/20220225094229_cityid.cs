using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class cityid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Persons_CityRulerId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CityRulerId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityRulerId",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId1",
                table: "Persons",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Cities_CityId",
                table: "Persons",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Cities_CityId1",
                table: "Persons",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Cities_CityId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Cities_CityId1",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CityId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CityId1",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "CityRulerId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CityRulerId",
                table: "Cities",
                column: "CityRulerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Persons_CityRulerId",
                table: "Cities",
                column: "CityRulerId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
