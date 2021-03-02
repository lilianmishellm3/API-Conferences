using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployedAPI.Migrations
{
    public partial class APIInicialversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    ConferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConferenceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConferenceDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.ConferenceId);
                });

            migrationBuilder.CreateTable(
                name: "SessionTalk",
                columns: table => new
                {
                    SessionTalkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionTalkName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpeakerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionTalk", x => x.SessionTalkId);
                    table.ForeignKey(
                        name: "FK_SessionTalk_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "ConferenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionTalk_ConferenceId",
                table: "SessionTalk",
                column: "ConferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionTalk");

            migrationBuilder.DropTable(
                name: "Conferences");
        }
    }
}
