using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Revenge.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Flavors",
                columns: table => new
                {
                    FlavorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FlavorName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flavors", x => x.FlavorID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Treats",
                columns: table => new
                {
                    TreatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TreatName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlavorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treats", x => x.TreatID);
                    table.ForeignKey(
                        name: "FK_Treats_Flavors_FlavorID",
                        column: x => x.FlavorID,
                        principalTable: "Flavors",
                        principalColumn: "FlavorID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FlavorTreats",
                columns: table => new
                {
                    FlavorTreatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FlavorID = table.Column<int>(type: "int", nullable: false),
                    TreatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlavorTreats", x => x.FlavorTreatID);
                    table.ForeignKey(
                        name: "FK_FlavorTreats_Flavors_FlavorID",
                        column: x => x.FlavorID,
                        principalTable: "Flavors",
                        principalColumn: "FlavorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlavorTreats_Treats_TreatID",
                        column: x => x.TreatID,
                        principalTable: "Treats",
                        principalColumn: "TreatID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FlavorTreats_FlavorID",
                table: "FlavorTreats",
                column: "FlavorID");

            migrationBuilder.CreateIndex(
                name: "IX_FlavorTreats_TreatID",
                table: "FlavorTreats",
                column: "TreatID");

            migrationBuilder.CreateIndex(
                name: "IX_Treats_FlavorID",
                table: "Treats",
                column: "FlavorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlavorTreats");

            migrationBuilder.DropTable(
                name: "Treats");

            migrationBuilder.DropTable(
                name: "Flavors");
        }
    }
}
