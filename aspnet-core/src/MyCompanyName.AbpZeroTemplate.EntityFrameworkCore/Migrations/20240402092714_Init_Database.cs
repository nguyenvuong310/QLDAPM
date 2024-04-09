using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Init_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PbExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Working_time = table.Column<int>(type: "int", nullable: false),
                    Mix_question = table.Column<bool>(type: "bit", nullable: false),
                    Redo_num = table.Column<int>(type: "int", nullable: false),
                    Point_is_cal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Review_wrong_ans = table.Column<bool>(type: "bit", nullable: false),
                    Review_right_ans = table.Column<bool>(type: "bit", nullable: false),
                    View_question_one = table.Column<bool>(type: "bit", nullable: false),
                    Require_password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Exam_type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Course = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PbExams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PbQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    Question_type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 65535, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", maxLength: 65535, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PbQuestions", x => new { x.Id, x.ExamId });
                    table.ForeignKey(
                        name: "FK_PbQuestions_PbExams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "PbExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PbExamFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PbExamFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PbExamFiles_PbQuestions_QuestionId_ExamId",
                        columns: x => new { x.QuestionId, x.ExamId },
                        principalTable: "PbQuestions",
                        principalColumns: new[] { "Id", "ExamId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PbExamFiles_QuestionId_ExamId",
                table: "PbExamFiles",
                columns: new[] { "QuestionId", "ExamId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PbQuestions_ExamId",
                table: "PbQuestions",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PbExamFiles");

            migrationBuilder.DropTable(
                name: "PbQuestions");

            migrationBuilder.DropTable(
                name: "PbExams");
        }
    }
}
