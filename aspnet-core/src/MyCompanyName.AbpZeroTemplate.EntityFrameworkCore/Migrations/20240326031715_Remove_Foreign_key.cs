using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Remove_Foreign_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PbExamFiles_PbQuestions_QuestionId",
                table: "PbExamFiles");

            migrationBuilder.DropIndex(
                name: "IX_PbExamFiles_QuestionId",
                table: "PbExamFiles");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "PbExamFiles");

            migrationBuilder.AddColumn<int>(
                name: "ExamFileId",
                table: "PbQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "PbExamFiles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "PbExamFiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PbExamFiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "PbExamFiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "PbExamFiles",
                type: "bigint",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "PbExamFiles");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "PbExamFiles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PbExamFiles");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "PbExamFiles");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "PbExamFiles");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "PbExamFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
