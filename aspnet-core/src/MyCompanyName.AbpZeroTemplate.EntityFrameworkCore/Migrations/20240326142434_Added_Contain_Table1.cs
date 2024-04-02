using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Added_Contain_Table1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_PbContains_QuesionId",
                table: "PbContains",
                column: "QuesionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PbContains_PbQuestions_QuesionId",
                table: "PbContains",
                column: "QuesionId",
                principalTable: "PbQuestions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PbContains_PbQuestions_QuesionId",
                table: "PbContains");

            migrationBuilder.DropIndex(
                name: "IX_PbContains_QuesionId",
                table: "PbContains");

            migrationBuilder.DropColumn(
                name: "QuesionId",
                table: "PbContains");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "PbContains");
        }
    }
}
