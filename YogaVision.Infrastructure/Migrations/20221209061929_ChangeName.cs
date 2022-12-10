using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaVision.Infrastructure.Migrations
{
    public partial class ChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YogaEventApplicationsUser");

            migrationBuilder.CreateTable(
                name: "YogaEventApplicationUser",
                columns: table => new
                {
                    YogaEventId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YogaEventApplicationUser", x => new { x.YogaEventId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_YogaEventApplicationUser_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YogaEventApplicationUser_YogaEvents_YogaEventId",
                        column: x => x.YogaEventId,
                        principalTable: "YogaEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YogaEventApplicationUser_ApplicationUserId",
                table: "YogaEventApplicationUser",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_YogaEventApplicationUser_IsDeleted",
                table: "YogaEventApplicationUser",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YogaEventApplicationUser");

            migrationBuilder.CreateTable(
                name: "YogaEventApplicationsUser",
                columns: table => new
                {
                    YogaEventId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YogaEventApplicationsUser", x => new { x.YogaEventId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_YogaEventApplicationsUser_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YogaEventApplicationsUser_YogaEvents_YogaEventId",
                        column: x => x.YogaEventId,
                        principalTable: "YogaEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YogaEventApplicationsUser_ApplicationUserId",
                table: "YogaEventApplicationsUser",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_YogaEventApplicationsUser_IsDeleted",
                table: "YogaEventApplicationsUser",
                column: "IsDeleted");
        }
    }
}
