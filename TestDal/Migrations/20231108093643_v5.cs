using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDal.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TooMany1Id",
                table: "Ones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TooMany1s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TooMany1s", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ones_TooMany1Id",
                table: "Ones",
                column: "TooMany1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ones_TooMany1s_TooMany1Id",
                table: "Ones",
                column: "TooMany1Id",
                principalTable: "TooMany1s",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ones_TooMany1s_TooMany1Id",
                table: "Ones");

            migrationBuilder.DropTable(
                name: "TooMany1s");

            migrationBuilder.DropIndex(
                name: "IX_Ones_TooMany1Id",
                table: "Ones");

            migrationBuilder.DropColumn(
                name: "TooMany1Id",
                table: "Ones");
        }
    }
}
