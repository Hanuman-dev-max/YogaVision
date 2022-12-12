using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaVision.Infrastructure.Migrations
{
    public partial class AddLikesBlogPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "BlogPosts");
        }
    }
}
