using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PostLectureReview.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lecture",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    URLCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecture", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    ParentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Question_Lecture_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Lecture",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    TopicID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Topic_Lecture_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Lecture",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topic_Topic_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_ParentID",
                table: "Question",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_ParentID",
                table: "Topic",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_TopicID",
                table: "Topic",
                column: "TopicID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Lecture");
        }
    }
}
