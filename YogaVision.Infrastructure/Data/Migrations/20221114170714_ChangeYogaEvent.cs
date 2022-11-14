using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaVision.Data.Migrations
{
    public partial class ChangeYogaEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YogaEvent_Studios_StudioId1",
                table: "YogaEvent");

            migrationBuilder.DropIndex(
                name: "IX_YogaEvent_StudioId1",
                table: "YogaEvent");

            migrationBuilder.DropColumn(
                name: "StudioId1",
                table: "YogaEvent");

            migrationBuilder.AlterColumn<string>(
                name: "StudioId",
                table: "YogaEvent",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_YogaEvent_StudioId",
                table: "YogaEvent",
                column: "StudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_YogaEvent_Studios_StudioId",
                table: "YogaEvent",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YogaEvent_Studios_StudioId",
                table: "YogaEvent");

            migrationBuilder.DropIndex(
                name: "IX_YogaEvent_StudioId",
                table: "YogaEvent");

            migrationBuilder.AlterColumn<int>(
                name: "StudioId",
                table: "YogaEvent",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "StudioId1",
                table: "YogaEvent",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_YogaEvent_StudioId1",
                table: "YogaEvent",
                column: "StudioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_YogaEvent_Studios_StudioId1",
                table: "YogaEvent",
                column: "StudioId1",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
