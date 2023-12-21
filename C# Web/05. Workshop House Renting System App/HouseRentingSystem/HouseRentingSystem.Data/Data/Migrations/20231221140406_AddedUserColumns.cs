using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Data.Migrations
{
    public partial class AddedUserColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "012223e6-437a-48d3-884c-84c714f9d406", "Teodor", "Lesly", "AQAAAAEAACcQAAAAEHz7tFvR+/GOtCcAviQJF/kyQaaeHK5JSd6BGiRbRo+StypGxRbBXhzfVs/g34J0sA==", "090a3d31-403a-4c0a-8e4b-fec44f5a34d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72ffe5a4-f541-4ce0-be99-32e9efcc6b81", "Linda", "Michaels", "AQAAAAEAACcQAAAAENxn+lWYpi273OGYaVnasMKjD5EjkmGWWLEfYIfFHiZUnns+eK08zcTw4kAsKZLpAA==", "8d5c567a-48c6-471a-a98d-cefc7784d91d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

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
        }
    }
}
