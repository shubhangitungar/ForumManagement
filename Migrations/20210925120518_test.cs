using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumManagement.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_questionid",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "questionid",
                table: "Answers",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_questionid",
                table: "Answers",
                newName: "IX_Answers_QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Answers",
                newName: "questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                newName: "IX_Answers_questionid");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_questionid",
                table: "Answers",
                column: "questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
