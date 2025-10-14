using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wcjj.Net.Bugz.Data.Migrations
{
    /// <inheritdoc />
    public partial class bug_lists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BugId",
                table: "Status_",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BugId",
                table: "Priorities",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BugId",
                table: "MimeTypes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Status__BugId",
                table: "Status_",
                column: "BugId");

            migrationBuilder.CreateIndex(
                name: "IX_Priorities_BugId",
                table: "Priorities",
                column: "BugId");

            migrationBuilder.CreateIndex(
                name: "IX_MimeTypes_BugId",
                table: "MimeTypes",
                column: "BugId");

            migrationBuilder.AddForeignKey(
                name: "FK_MimeTypes_Bugs_BugId",
                table: "MimeTypes",
                column: "BugId",
                principalTable: "Bugs",
                principalColumn: "BugId");

            migrationBuilder.AddForeignKey(
                name: "FK_Priorities_Bugs_BugId",
                table: "Priorities",
                column: "BugId",
                principalTable: "Bugs",
                principalColumn: "BugId");

            migrationBuilder.AddForeignKey(
                name: "FK_Status__Bugs_BugId",
                table: "Status_",
                column: "BugId",
                principalTable: "Bugs",
                principalColumn: "BugId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MimeTypes_Bugs_BugId",
                table: "MimeTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Priorities_Bugs_BugId",
                table: "Priorities");

            migrationBuilder.DropForeignKey(
                name: "FK_Status__Bugs_BugId",
                table: "Status_");

            migrationBuilder.DropIndex(
                name: "IX_Status__BugId",
                table: "Status_");

            migrationBuilder.DropIndex(
                name: "IX_Priorities_BugId",
                table: "Priorities");

            migrationBuilder.DropIndex(
                name: "IX_MimeTypes_BugId",
                table: "MimeTypes");

            migrationBuilder.DropColumn(
                name: "BugId",
                table: "Status_");

            migrationBuilder.DropColumn(
                name: "BugId",
                table: "Priorities");

            migrationBuilder.DropColumn(
                name: "BugId",
                table: "MimeTypes");
        }
    }
}
