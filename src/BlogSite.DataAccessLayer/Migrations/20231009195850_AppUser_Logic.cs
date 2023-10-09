using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.DataAccessLayer.Migrations
{
    public partial class AppUser_Logic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writers_RecieverId",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writers_SenderId",
                table: "Message2s");

            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Message2s",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WriterId1",
                table: "Message2s",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_WriterId",
                table: "Message2s",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_WriterId1",
                table: "Message2s",
                column: "WriterId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_AspNetUsers_RecieverId",
                table: "Message2s",
                column: "RecieverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_AspNetUsers_SenderId",
                table: "Message2s",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writers_WriterId",
                table: "Message2s",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writers_WriterId1",
                table: "Message2s",
                column: "WriterId1",
                principalTable: "Writers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_AspNetUsers_RecieverId",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_AspNetUsers_SenderId",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writers_WriterId",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writers_WriterId1",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_WriterId",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_WriterId1",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Message2s");

            migrationBuilder.DropColumn(
                name: "WriterId1",
                table: "Message2s");

            migrationBuilder.DropColumn(
                name: "About",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writers_RecieverId",
                table: "Message2s",
                column: "RecieverId",
                principalTable: "Writers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writers_SenderId",
                table: "Message2s",
                column: "SenderId",
                principalTable: "Writers",
                principalColumn: "Id");
        }
    }
}
