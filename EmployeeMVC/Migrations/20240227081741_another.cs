using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeMVC.Migrations
{
    public partial class another : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "32036e1d-5912-4500-a441-703053b89d50", "a017b428-0e3a-4c20-9fb3-200300bf37fb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8a6d1b4d-0c5f-4d0f-bbb8-2373530aae50", "a017b428-0e3a-4c20-9fb3-200300bf37fb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a7d053b7-e6f7-49b6-b0b4-b0d5f18643dc", "a017b428-0e3a-4c20-9fb3-200300bf37fb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32036e1d-5912-4500-a441-703053b89d50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a6d1b4d-0c5f-4d0f-bbb8-2373530aae50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7d053b7-e6f7-49b6-b0b4-b0d5f18643dc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a017b428-0e3a-4c20-9fb3-200300bf37fb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f87bb0d1-7ffb-4ab3-897c-48ec1a687e45", "3", "User", "USER" },
                    { "fce70b76-cfde-4de3-8b09-311e96bedc44", "1", "SuperAdmin", "SUPERADMIN" },
                    { "fd6f0563-1227-452f-8247-2ff753042695", "2", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c80910c1-f8f1-4bb0-88c1-99b15d5b5b5b", 0, "64c0b23e-dcc7-492b-a2bc-453b69ac5a0c", "superadmin@gmail.com", false, true, null, null, "SUPERADMIN", "AQAAAAEAACcQAAAAECjD+9RWFRFDtsAUrE+8XMHQKgiPQoD4qUG9a00YyiO9+L5IFRvU4ac2BCgtV93zmA==", null, false, "0a6fad7a-5667-468f-8324-30070200e47c", false, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f87bb0d1-7ffb-4ab3-897c-48ec1a687e45", "c80910c1-f8f1-4bb0-88c1-99b15d5b5b5b" },
                    { "fce70b76-cfde-4de3-8b09-311e96bedc44", "c80910c1-f8f1-4bb0-88c1-99b15d5b5b5b" },
                    { "fd6f0563-1227-452f-8247-2ff753042695", "c80910c1-f8f1-4bb0-88c1-99b15d5b5b5b" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f87bb0d1-7ffb-4ab3-897c-48ec1a687e45", "c80910c1-f8f1-4bb0-88c1-99b15d5b5b5b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fce70b76-cfde-4de3-8b09-311e96bedc44", "c80910c1-f8f1-4bb0-88c1-99b15d5b5b5b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fd6f0563-1227-452f-8247-2ff753042695", "c80910c1-f8f1-4bb0-88c1-99b15d5b5b5b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f87bb0d1-7ffb-4ab3-897c-48ec1a687e45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fce70b76-cfde-4de3-8b09-311e96bedc44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd6f0563-1227-452f-8247-2ff753042695");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c80910c1-f8f1-4bb0-88c1-99b15d5b5b5b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32036e1d-5912-4500-a441-703053b89d50", "3", "User", "USER" },
                    { "8a6d1b4d-0c5f-4d0f-bbb8-2373530aae50", "2", "Admin", "ADMIN" },
                    { "a7d053b7-e6f7-49b6-b0b4-b0d5f18643dc", "1", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a017b428-0e3a-4c20-9fb3-200300bf37fb", 0, "54bca3cc-234d-4309-9635-3729d0196b53", "superadmin@gmail.com", false, true, null, null, "SUPERADMIN", "AQAAAAEAACcQAAAAEKdYqN8LeFAw7dJDcEUbvFUNWILR3cXskAl395FpHCG+xegso7RRssPwvsS2PjTUNQ==", null, false, "83b9800f-b988-441f-badb-82279f8d01d8", false, "SperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "32036e1d-5912-4500-a441-703053b89d50", "a017b428-0e3a-4c20-9fb3-200300bf37fb" },
                    { "8a6d1b4d-0c5f-4d0f-bbb8-2373530aae50", "a017b428-0e3a-4c20-9fb3-200300bf37fb" },
                    { "a7d053b7-e6f7-49b6-b0b4-b0d5f18643dc", "a017b428-0e3a-4c20-9fb3-200300bf37fb" }
                });
        }
    }
}
