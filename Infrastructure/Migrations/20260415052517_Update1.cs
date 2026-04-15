using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41ba399f-2da6-4ddd-bb5a-7267d3e17e13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d171334-e184-4eb8-8c24-9f5a39d3f645");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e4dedb4-1604-459c-bc79-6f40d4533da2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61b90e34-cea8-4c99-b910-84325dfb49f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e647b98b-21b0-4bc3-b380-8880aca08c20");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1660752e-8cb5-435c-ab6d-10d460dbc4e7", null, "Administrator role", "Administrator", null },
                    { "2c8b52ea-b47f-474e-9e94-b07408e510dc", null, "Support Agent role", "SupportAgent", null },
                    { "8f972e19-8452-4b1e-9b98-a578a9f09963", null, "Read Only role", "ReadOnly", null },
                    { "b5844a0f-4749-4601-b9df-047da1c8a265", null, "Salesperson role", "Salesperson", null },
                    { "f71a378e-d53f-408c-a716-22e43c35062c", null, "Sales Manager role", "SalesManager", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "7459f626-3234-4443-ac71-14b08ed0fda6", new DateTime(2026, 4, 15, 7, 25, 17, 471, DateTimeKind.Local).AddTicks(4501), "8fc8904e-5282-4ad6-b5ae-b8e8a0331a50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "56c763eb-6fb4-439e-9dae-211883cadb23", new DateTime(2026, 4, 15, 7, 25, 17, 471, DateTimeKind.Local).AddTicks(4767), "b997f5b2-b4ac-42c9-89ce-fbad990011c3" });

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("3d54091d-abc8-49ec-9590-93ad3ed5458f"),
                columns: new[] { "DateTimeCreatedAt", "DateTimeUpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 15, 7, 25, 17, 459, DateTimeKind.Local).AddTicks(3150), new DateTime(2026, 4, 15, 7, 25, 17, 460, DateTimeKind.Local).AddTicks(4733) });

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("b4dcb17c-f875-43f8-9d66-36597895a466"),
                columns: new[] { "DateTimeCreatedAt", "DateTimeUpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 15, 7, 25, 17, 460, DateTimeKind.Local).AddTicks(5524), new DateTime(2026, 4, 15, 7, 25, 17, 460, DateTimeKind.Local).AddTicks(5530) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1660752e-8cb5-435c-ab6d-10d460dbc4e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c8b52ea-b47f-474e-9e94-b07408e510dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f972e19-8452-4b1e-9b98-a578a9f09963");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5844a0f-4749-4601-b9df-047da1c8a265");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f71a378e-d53f-408c-a716-22e43c35062c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41ba399f-2da6-4ddd-bb5a-7267d3e17e13", null, "Read Only role", "ReadOnly", null },
                    { "4d171334-e184-4eb8-8c24-9f5a39d3f645", null, "Administrator role", "Administrator", null },
                    { "5e4dedb4-1604-459c-bc79-6f40d4533da2", null, "Salesperson role", "Salesperson", null },
                    { "61b90e34-cea8-4c99-b910-84325dfb49f8", null, "Sales Manager role", "SalesManager", null },
                    { "e647b98b-21b0-4bc3-b380-8880aca08c20", null, "Support Agent role", "SupportAgent", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "696817ea-db8c-4587-b764-7e918a11f19b", new DateTime(2026, 4, 15, 7, 23, 43, 891, DateTimeKind.Local).AddTicks(4230), "b8aa8d88-ffc6-4e71-8b12-f6166a8a32ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "b5f51595-46b9-435f-884a-103281c3eb45", new DateTime(2026, 4, 15, 7, 23, 43, 891, DateTimeKind.Local).AddTicks(4413), "d291af8d-4e3d-4b32-94cd-3125c2c18740" });

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("3d54091d-abc8-49ec-9590-93ad3ed5458f"),
                columns: new[] { "DateTimeCreatedAt", "DateTimeUpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 15, 7, 23, 43, 879, DateTimeKind.Local).AddTicks(1030), new DateTime(2026, 4, 15, 7, 23, 43, 880, DateTimeKind.Local).AddTicks(2381) });

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("b4dcb17c-f875-43f8-9d66-36597895a466"),
                columns: new[] { "DateTimeCreatedAt", "DateTimeUpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 15, 7, 23, 43, 880, DateTimeKind.Local).AddTicks(3226), new DateTime(2026, 4, 15, 7, 23, 43, 880, DateTimeKind.Local).AddTicks(3233) });
        }
    }
}
