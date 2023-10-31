using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class SeedDataImageChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Houses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99accd2b-6bbf-4e58-96ba-02bbe3f335f7", "AQAAAAEAACcQAAAAEJjAUgeSA2tQWEuAG2NbEZ5YWrNDCnbtWwwoDsRRw7Kx+Q+u6r0KAoZ3FVY2AN35JA==", "7e7e17e1-2e41-4e69-94dd-17035db393a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3875fc17-709d-4430-ae0e-821c8421b182", "AQAAAAEAACcQAAAAEFPwJ0HB+mPScDl1L/uN6wAJWifhQ8fKBmeT/mvwdH0mkH9HDVvajpw7QPB8VLfiQA==", "7a4759a8-2d34-4a22-80fc-0dc7a1f79e47" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://static8.depositphotos.com/1392258/871/i/450/depositphotos_8711701-Large-luxury-brick-home.jpg");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_RenterId",
                table: "Houses",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_AspNetUsers_RenterId",
                table: "Houses",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_AspNetUsers_RenterId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_RenterId",
                table: "Houses");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5b57395-0887-4fd9-bf3a-f126d547dd26", "AQAAAAEAACcQAAAAENOcrMTssHaF1cBNXuQTXzQOQe3gyll8SaO5WUP2jKqKyCV2BQG3eSaNZLa/WmCwSA==", "9538c8db-ab74-4aa6-ab98-82c0af5dbd2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf86b037-4d90-4ec1-a3f3-42d6895ff06e", "AQAAAAEAACcQAAAAEOy9YUeRhF+k3HY47yGGo0Z/i3RyeLqRbJcL58XQ7yFfDn/yGF/IBfP07Q8AbbhPXA==", "162b22bf-512f-4681-baf6-4d7564d16820" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg");
        }
    }
}
