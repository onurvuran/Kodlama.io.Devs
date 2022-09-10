using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Technologys");

            migrationBuilder.CreateTable(
                name: "LanguageTechnologys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageTechnologyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTechnologys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageTechnologys_Languages_LanguageTechnologyId",
                        column: x => x.LanguageTechnologyId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LanguageTechnologys",
                columns: new[] { "Id", "LanguageTechnologyId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Selenium" },
                    { 2, 2, "ASP.Net" },
                    { 3, 3, "Angular" },
                    { 4, 4, "Angular" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTechnologys_LanguageTechnologyId",
                table: "LanguageTechnologys",
                column: "LanguageTechnologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageTechnologys");

            migrationBuilder.CreateTable(
                name: "Technologys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnologyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technologys_Languages_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Technologys",
                columns: new[] { "Id", "TechnologyId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Selenium" },
                    { 2, 2, "ASP.Net" },
                    { 3, 3, "Angular" },
                    { 4, 4, "Angular" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Technologys_TechnologyId",
                table: "Technologys",
                column: "TechnologyId");
        }
    }
}
