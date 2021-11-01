using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastCourse.Migrations
{
    public partial class NewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Certificate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "VideoLessonHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoLessonId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoLessonHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoLessonHistory_VideoLesson_VideoLessonId",
                        column: x => x.VideoLessonId,
                        principalTable: "VideoLesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_CourseId",
                table: "Certificate",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoLessonHistory_VideoLessonId",
                table: "VideoLessonHistory",
                column: "VideoLessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_Course_CourseId",
                table: "Certificate",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_Course_CourseId",
                table: "Certificate");

            migrationBuilder.DropTable(
                name: "VideoLessonHistory");

            migrationBuilder.DropIndex(
                name: "IX_Certificate_CourseId",
                table: "Certificate");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Certificate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
