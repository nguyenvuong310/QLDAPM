using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Updated_Contain_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PbContains_PbQuestions_QuestionId",
                table: "PbContains");

            migrationBuilder.DropIndex(
                name: "IX_PbContains_QuestionId",
                table: "PbContains");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "PbContains");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "PbContains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PbContains_QuestionId",
                table: "PbContains",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PbContains_PbQuestions_QuestionId",
                table: "PbContains",
                column: "QuestionId",
                principalTable: "PbQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
