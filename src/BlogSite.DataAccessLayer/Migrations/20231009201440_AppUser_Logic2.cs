using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSite.DataAccessLayer.Migrations
{
    public partial class AppUser_Logic2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Writers_WriterId",
                table: "Blogs");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_WriterId",
                table: "Blogs",
                column: "WriterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_WriterId",
                table: "Blogs");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Writers_WriterId",
                table: "Blogs",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "Id");
        }
    }
}
