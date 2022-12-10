using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaVision.Infrastructure.Migrations
{
    public partial class AddDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YogaEventApplicationUser_AspNetUsers_ApplicationUserId",
                table: "YogaEventApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_YogaEventApplicationUser_YogaEvents_YogaEventId",
                table: "YogaEventApplicationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YogaEventApplicationUser",
                table: "YogaEventApplicationUser");

            migrationBuilder.RenameTable(
                name: "YogaEventApplicationUser",
                newName: "YogaEventApplicationUsers");

            migrationBuilder.RenameIndex(
                name: "IX_YogaEventApplicationUser_IsDeleted",
                table: "YogaEventApplicationUsers",
                newName: "IX_YogaEventApplicationUsers_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_YogaEventApplicationUser_ApplicationUserId",
                table: "YogaEventApplicationUsers",
                newName: "IX_YogaEventApplicationUsers_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YogaEventApplicationUsers",
                table: "YogaEventApplicationUsers",
                columns: new[] { "YogaEventId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_YogaEventApplicationUsers_AspNetUsers_ApplicationUserId",
                table: "YogaEventApplicationUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YogaEventApplicationUsers_YogaEvents_YogaEventId",
                table: "YogaEventApplicationUsers",
                column: "YogaEventId",
                principalTable: "YogaEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YogaEventApplicationUsers_AspNetUsers_ApplicationUserId",
                table: "YogaEventApplicationUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_YogaEventApplicationUsers_YogaEvents_YogaEventId",
                table: "YogaEventApplicationUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YogaEventApplicationUsers",
                table: "YogaEventApplicationUsers");

            migrationBuilder.RenameTable(
                name: "YogaEventApplicationUsers",
                newName: "YogaEventApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_YogaEventApplicationUsers_IsDeleted",
                table: "YogaEventApplicationUser",
                newName: "IX_YogaEventApplicationUser_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_YogaEventApplicationUsers_ApplicationUserId",
                table: "YogaEventApplicationUser",
                newName: "IX_YogaEventApplicationUser_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YogaEventApplicationUser",
                table: "YogaEventApplicationUser",
                columns: new[] { "YogaEventId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_YogaEventApplicationUser_AspNetUsers_ApplicationUserId",
                table: "YogaEventApplicationUser",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YogaEventApplicationUser_YogaEvents_YogaEventId",
                table: "YogaEventApplicationUser",
                column: "YogaEventId",
                principalTable: "YogaEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
