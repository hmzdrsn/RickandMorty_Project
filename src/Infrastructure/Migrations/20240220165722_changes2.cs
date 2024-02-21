using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Residents");

            migrationBuilder.CreateTable(
                name: "Resident",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locationid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resident", x => x.id);
                    table.ForeignKey(
                        name: "FK_Resident_Locations_Locationid",
                        column: x => x.Locationid,
                        principalTable: "Locations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resident_Locationid",
                table: "Resident",
                column: "Locationid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resident");

            migrationBuilder.CreateTable(
                name: "Residents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Locationid = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residents", x => x.id);
                    table.ForeignKey(
                        name: "FK_Residents_Locations_Locationid",
                        column: x => x.Locationid,
                        principalTable: "Locations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Residents_Locationid",
                table: "Residents",
                column: "Locationid");
        }
    }
}
