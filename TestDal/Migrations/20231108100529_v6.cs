using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDal.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TooMany2s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TooMany2s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManyTooMany2",
                columns: table => new
                {
                    ManysId = table.Column<int>(type: "int", nullable: false),
                    TooMany2sId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyTooMany2", x => new { x.ManysId, x.TooMany2sId });
                    table.ForeignKey(
                        name: "FK_ManyTooMany2_Manys_ManysId",
                        column: x => x.ManysId,
                        principalTable: "Manys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManyTooMany2_TooMany2s_TooMany2sId",
                        column: x => x.TooMany2sId,
                        principalTable: "TooMany2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManyTooMany2_TooMany2sId",
                table: "ManyTooMany2",
                column: "TooMany2sId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManyTooMany2");

            migrationBuilder.DropTable(
                name: "Manys");

            migrationBuilder.DropTable(
                name: "TooMany2s");
        }
    }
}
