using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Added_Topics_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PbQuestions_PbExamFiles_ExamFileId",
                table: "PbQuestions");

            migrationBuilder.DropIndex(
                name: "IX_PbQuestions_ExamFileId",
                table: "PbQuestions");

            migrationBuilder.DropColumn(
                name: "ExamFileId",
                table: "PbQuestions");

            migrationBuilder.CreateTable(
                name: "PbTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question_link = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Answer_link = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Max_question = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
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
                    table.PrimaryKey("PK_PbTopics", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PbTopics");

            migrationBuilder.AddColumn<int>(
                name: "ExamFileId",
                table: "PbQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PbQuestions_ExamFileId",
                table: "PbQuestions",
                column: "ExamFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_PbQuestions_PbExamFiles_ExamFileId",
                table: "PbQuestions",
                column: "ExamFileId",
                principalTable: "PbExamFiles",
                principalColumn: "Id");
        }
    }
}
