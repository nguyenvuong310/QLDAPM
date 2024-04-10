using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Update_Update_Questions_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherAnswer1",
                table: "PbQuestions",
                type: "nvarchar(max)",
                maxLength: 65535,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherAnswer2",
                table: "PbQuestions",
                type: "nvarchar(max)",
                maxLength: 65535,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherAnswer1",
                table: "PbQuestions");

            migrationBuilder.DropColumn(
                name: "OtherAnswer2",
                table: "PbQuestions");
        }
    }
}
