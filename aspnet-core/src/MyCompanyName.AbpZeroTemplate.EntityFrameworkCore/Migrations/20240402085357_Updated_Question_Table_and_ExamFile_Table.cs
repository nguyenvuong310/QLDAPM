using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Updated_Question_Table_and_ExamFile_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PbExamFiles_PbQuestions_QuestionId",
                table: "PbExamFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PbQuestions",
                table: "PbQuestions");

            migrationBuilder.DropIndex(
                name: "IX_PbExamFiles_QuestionId",
                table: "PbExamFiles");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "PbExamFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PbQuestions",
                table: "PbQuestions",
                columns: new[] { "Id", "ExamId" });

            migrationBuilder.CreateIndex(
                name: "IX_PbExamFiles_QuestionId_ExamId",
                table: "PbExamFiles",
                columns: new[] { "QuestionId", "ExamId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PbExamFiles_PbQuestions_QuestionId_ExamId",
                table: "PbExamFiles",
                columns: new[] { "QuestionId", "ExamId" },
                principalTable: "PbQuestions",
                principalColumns: new[] { "Id", "ExamId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PbExamFiles_PbQuestions_QuestionId_ExamId",
                table: "PbExamFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PbQuestions",
                table: "PbQuestions");

            migrationBuilder.DropIndex(
                name: "IX_PbExamFiles_QuestionId_ExamId",
                table: "PbExamFiles");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "PbExamFiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PbQuestions",
                table: "PbQuestions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PbExamFiles_QuestionId",
                table: "PbExamFiles",
                column: "QuestionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PbExamFiles_PbQuestions_QuestionId",
                table: "PbExamFiles",
                column: "QuestionId",
                principalTable: "PbQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
