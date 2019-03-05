using Microsoft.EntityFrameworkCore.Migrations;

namespace PostLectureReview.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Lecture_ParentID",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Lecture_ParentID",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Topic_TopicID",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Topic_TopicID",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Question_ParentID",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "TopicID",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "Question");

            migrationBuilder.AddColumn<bool>(
                name: "DeleteTopic",
                table: "Topic",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LectureID",
                table: "Topic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DeleteQuestion",
                table: "Question",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LectureID",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Topic_LectureID",
                table: "Topic",
                column: "LectureID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_LectureID",
                table: "Question",
                column: "LectureID");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Lecture_LectureID",
                table: "Question",
                column: "LectureID",
                principalTable: "Lecture",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Lecture_LectureID",
                table: "Topic",
                column: "LectureID",
                principalTable: "Lecture",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Topic_ParentID",
                table: "Topic",
                column: "ParentID",
                principalTable: "Topic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Lecture_LectureID",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Lecture_LectureID",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Topic_ParentID",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Topic_LectureID",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Question_LectureID",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "DeleteTopic",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "LectureID",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "DeleteQuestion",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "LectureID",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "TopicID",
                table: "Topic",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "Question",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topic_TopicID",
                table: "Topic",
                column: "TopicID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ParentID",
                table: "Question",
                column: "ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Lecture_ParentID",
                table: "Question",
                column: "ParentID",
                principalTable: "Lecture",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Lecture_ParentID",
                table: "Topic",
                column: "ParentID",
                principalTable: "Lecture",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Topic_TopicID",
                table: "Topic",
                column: "TopicID",
                principalTable: "Topic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
