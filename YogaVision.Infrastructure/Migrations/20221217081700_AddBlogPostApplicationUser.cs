using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaVision.Infrastructure.Migrations
{
    public partial class AddBlogPostApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPostApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogPostId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostApplicationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostApplicationUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogPostApplicationUsers_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostApplicationUsers_ApplicationUserId",
                table: "BlogPostApplicationUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostApplicationUsers_BlogPostId",
                table: "BlogPostApplicationUsers",
                column: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostApplicationUsers_IsDeleted",
                table: "BlogPostApplicationUsers",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostApplicationUsers");
        }
    }
}
