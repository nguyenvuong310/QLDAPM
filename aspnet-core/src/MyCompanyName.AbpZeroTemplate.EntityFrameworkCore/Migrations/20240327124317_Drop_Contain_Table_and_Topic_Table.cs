using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Drop_Contain_Table_and_Topic_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PbContains_PbQuestions_QuesionId",
                table: "PbContains");

            migrationBuilder.DropForeignKey(
                name: "FK_PbContains_PbTopics_TopicId",
                table: "PbContains");

            migrationBuilder.DropForeignKey(
                name: "FK_PbExams_PbTopics_TopicId",
                table: "PbExams");

            migrationBuilder.DropIndex(
                name: "IX_PbExams_TopicId",
                table: "PbExams");

            migrationBuilder.DropIndex(
                name: "IX_PbContains_QuesionId",
                table: "PbContains");

            migrationBuilder.DropIndex(
                name: "IX_PbContains_TopicId",
                table: "PbContains");

            migrationBuilder.DropColumn(
                name: "Answer_link",
                table: "PbTopics");

            migrationBuilder.DropColumn(
                name: "Max_question",
                table: "PbTopics");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PbTopics");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "QuesionId",
                table: "PbContains");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "PbContains");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "PbContains");

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "PbExams",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "PbExams",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PbExams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "PbExams",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "PbExams",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "PbContains",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "PbContains",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PbContains",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "PbContains",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "PbContains",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "PbContains");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "PbContains");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PbContains");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "PbContains");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "PbContains");

            migrationBuilder.AddColumn<string>(
                name: "Answer_link",
                table: "PbTopics",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Max_question",
                table: "PbTopics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "Type",
                table: "PbTopics",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "PbExams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuesionId",
                table: "PbContains",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "PbContains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "PbContains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PbExams_TopicId",
                table: "PbExams",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_PbContains_QuesionId",
                table: "PbContains",
                column: "QuesionId");

            migrationBuilder.CreateIndex(
                name: "IX_PbContains_TopicId",
                table: "PbContains",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_PbContains_PbQuestions_QuesionId",
                table: "PbContains",
                column: "QuesionId",
                principalTable: "PbQuestions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PbContains_PbTopics_TopicId",
                table: "PbContains",
                column: "TopicId",
                principalTable: "PbTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PbExams_PbTopics_TopicId",
                table: "PbExams",
                column: "TopicId",
                principalTable: "PbTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
