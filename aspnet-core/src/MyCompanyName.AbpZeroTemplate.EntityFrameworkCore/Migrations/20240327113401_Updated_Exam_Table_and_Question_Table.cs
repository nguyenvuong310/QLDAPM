using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Updated_Exam_Table_and_Question_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Join",
                table: "PbExams");

            migrationBuilder.RenameColumn(
                name: "Time_amount",
                table: "PbExams",
                newName: "Working_time");

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "PbQuestions",
                type: "nvarchar(max)",
                maxLength: 65535,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 65535);

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "PbQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "PbQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Question_type",
                table: "PbQuestions",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "PbExams",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "End_date",
                table: "PbExams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Exam_type",
                table: "PbExams",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Mix_question",
                table: "PbExams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Point_is_cal",
                table: "PbExams",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Redo_num",
                table: "PbExams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Require_password",
                table: "PbExams",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Review_right_ans",
                table: "PbExams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Review_wrong_ans",
                table: "PbExams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start_date",
                table: "PbExams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "View_question_one",
                table: "PbExams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_PbQuestions_ExamId",
                table: "PbQuestions",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_PbQuestions_PbExams_ExamId",
                table: "PbQuestions",
                column: "ExamId",
                principalTable: "PbExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PbQuestions_PbExams_ExamId",
                table: "PbQuestions");

            migrationBuilder.DropIndex(
                name: "IX_PbQuestions_ExamId",
                table: "PbQuestions");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "PbQuestions");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "PbQuestions");

            migrationBuilder.DropColumn(
                name: "Question_type",
                table: "PbQuestions");

            migrationBuilder.DropColumn(
                name: "Course",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "End_date",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "Exam_type",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "Mix_question",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "Point_is_cal",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "Redo_num",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "Require_password",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "Review_right_ans",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "Review_wrong_ans",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "Start_date",
                table: "PbExams");

            migrationBuilder.DropColumn(
                name: "View_question_one",
                table: "PbExams");

            migrationBuilder.RenameColumn(
                name: "Working_time",
                table: "PbExams",
                newName: "Time_amount");

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "PbQuestions",
                type: "nvarchar(max)",
                maxLength: 65535,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 65535,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Join",
                table: "PbExams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
