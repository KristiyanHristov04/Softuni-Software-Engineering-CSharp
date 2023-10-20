using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class AddedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e5a9418c-b212-45c4-88fd-d24886a8e60f", 0, "9cb8d42e-fe39-41f3-8c17-a6cc309112b8", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAECCacT6giL9taQ2UlOUy70mrxyonyJzNN1LIYK+KzsOMvbfeWLtINBcwnXhpidhbyA==", null, false, "a5cd83c0-cad5-4cef-bb64-8a3353f54438", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 9, 23, 34, 23, 912, DateTimeKind.Local).AddTicks(1318), "Implement better styling for all public pages", "e5a9418c-b212-45c4-88fd-d24886a8e60f", "Improve CSS Styles" },
                    { 2, 1, new DateTime(2023, 4, 25, 23, 34, 23, 912, DateTimeKind.Local).AddTicks(1360), "Create Android client app for the TaskBoard RESTful API", "e5a9418c-b212-45c4-88fd-d24886a8e60f", "Androind Client App" },
                    { 3, 2, new DateTime(2023, 8, 25, 23, 34, 23, 912, DateTimeKind.Local).AddTicks(1366), "Create Windows Forms desktop app for the TaskBoard RESTful API", "e5a9418c-b212-45c4-88fd-d24886a8e60f", "Desktop Client App" },
                    { 4, 3, new DateTime(2022, 9, 25, 23, 34, 23, 912, DateTimeKind.Local).AddTicks(1370), "Implement [Create Task] page for adding new tasks", "e5a9418c-b212-45c4-88fd-d24886a8e60f", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5a9418c-b212-45c4-88fd-d24886a8e60f");
        }
    }
}
