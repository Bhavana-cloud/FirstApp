using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabDal.Migrations
{
    public partial class a3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.CreateTable(
                name: "toomanycourses",
                columns: table => new
                {
                    Courseid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coursename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toomanycourses", x => x.Courseid);
                });

            migrationBuilder.CreateTable(
                name: "TooManyStudents",
                columns: table => new
                {
                    studentid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TooManyStudents", x => x.studentid);
                });

            migrationBuilder.CreateTable(
                name: "onestudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    toomanycourseCourseid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_onestudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_onestudents_toomanycourses_toomanycourseCourseid",
                        column: x => x.toomanycourseCourseid,
                        principalTable: "toomanycourses",
                        principalColumn: "Courseid");
                });

            migrationBuilder.CreateTable(
                name: "onecourses",
                columns: table => new
                {
                    onecourseid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    onecourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TooManyStudentstudentid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_onecourses", x => x.onecourseid);
                    table.ForeignKey(
                        name: "FK_onecourses_TooManyStudents_TooManyStudentstudentid",
                        column: x => x.TooManyStudentstudentid,
                        principalTable: "TooManyStudents",
                        principalColumn: "studentid");
                });

            migrationBuilder.CreateTable(
                name: "onecompanys",
                columns: table => new
                {
                    companyid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    onestudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_onecompanys", x => x.companyid);
                    table.ForeignKey(
                        name: "FK_onecompanys_onestudents_onestudentsId",
                        column: x => x.onestudentsId,
                        principalTable: "onestudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_onecompanys_onestudentsId",
                table: "onecompanys",
                column: "onestudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_onecourses_TooManyStudentstudentid",
                table: "onecourses",
                column: "TooManyStudentstudentid");

            migrationBuilder.CreateIndex(
                name: "IX_onestudents_toomanycourseCourseid",
                table: "onestudents",
                column: "toomanycourseCourseid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "onecompanys");

            migrationBuilder.DropTable(
                name: "onecourses");

            migrationBuilder.DropTable(
                name: "onestudents");

            migrationBuilder.DropTable(
                name: "TooManyStudents");

            migrationBuilder.DropTable(
                name: "toomanycourses");

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Courseid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coursename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Courseid);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Courseid = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_courses_Courseid",
                        column: x => x.Courseid,
                        principalTable: "courses",
                        principalColumn: "Courseid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Courseid",
                table: "Students",
                column: "Courseid");
        }
    }
}
