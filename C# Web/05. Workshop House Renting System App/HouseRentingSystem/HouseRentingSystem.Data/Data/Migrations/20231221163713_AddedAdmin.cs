using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Data.Migrations
{
    public partial class AddedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70e1b6ff-f514-4c7f-adfa-1ee814f7ee24", "AQAAAAEAACcQAAAAEMSQ98ckClADFREtrkbt+XA6R36gq6P7hAfPIO4f7ojTLJvBd4lrbP5wvlfPUV4+8Q==", "d303a888-23d8-4058-ad56-723e1377d6a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7004eb99-758a-4eeb-af5c-e7efd24b2d74", "AQAAAAEAACcQAAAAEKIFaXZ5fsXq2TcZJ+T1Ojho0CjCR3xT2+VIbLz3Ekv3d3jaQNhiDEBkkDQaC9wV8w==", "e7a27a9a-305e-452a-8cfb-945fdce44633" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "d5962a33-c51a-4ff3-adc3-c442a787c725", "admin@mail.com", false, "Great", "Admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAENUjr98B3Bn6LhAwXxycXc8DYXMzRMZNE10NlddAHjcP3b22J6sT1qXTb9TiIjrdqA==", null, false, "aa2cd8e2-f6fa-4ecd-ad6f-cedf9c239f38", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 2, "+359123456789", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "012223e6-437a-48d3-884c-84c714f9d406", "AQAAAAEAACcQAAAAEHz7tFvR+/GOtCcAviQJF/kyQaaeHK5JSd6BGiRbRo+StypGxRbBXhzfVs/g34J0sA==", "090a3d31-403a-4c0a-8e4b-fec44f5a34d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72ffe5a4-f541-4ce0-be99-32e9efcc6b81", "AQAAAAEAACcQAAAAENxn+lWYpi273OGYaVnasMKjD5EjkmGWWLEfYIfFHiZUnns+eK08zcTw4kAsKZLpAA==", "8d5c567a-48c6-471a-a98d-cefc7784d91d" });
        }
    }
}
