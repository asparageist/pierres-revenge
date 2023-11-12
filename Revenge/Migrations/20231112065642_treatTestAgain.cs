using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Revenge.Migrations
{
    public partial class treatTestAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treats_Flavors_FlavorID",
                table: "Treats");

            migrationBuilder.AlterColumn<int>(
                name: "FlavorID",
                table: "Treats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Flavor",
                table: "Treats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Treats_Flavors_FlavorID",
                table: "Treats",
                column: "FlavorID",
                principalTable: "Flavors",
                principalColumn: "FlavorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treats_Flavors_FlavorID",
                table: "Treats");

            migrationBuilder.DropColumn(
                name: "Flavor",
                table: "Treats");

            migrationBuilder.AlterColumn<int>(
                name: "FlavorID",
                table: "Treats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Treats_Flavors_FlavorID",
                table: "Treats",
                column: "FlavorID",
                principalTable: "Flavors",
                principalColumn: "FlavorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
