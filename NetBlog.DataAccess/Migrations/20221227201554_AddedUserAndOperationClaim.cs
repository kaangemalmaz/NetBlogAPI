using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetBlog.DataAccess.Migrations
{
    public partial class AddedUserAndOperationClaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 15, 53, 385, DateTimeKind.Utc).AddTicks(7199), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 15, 53, 385, DateTimeKind.Utc).AddTicks(7202), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 15, 53, 385, DateTimeKind.Utc).AddTicks(7203), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 15, 53, 385, DateTimeKind.Utc).AddTicks(7205), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 15, 53, 385, DateTimeKind.Utc).AddTicks(7206), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 15, 53, 385, DateTimeKind.Utc).AddTicks(7208), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 15, 53, 385, DateTimeKind.Utc).AddTicks(7209), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 15, 53, 385, DateTimeKind.Utc).AddTicks(7211), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 15, 53, 385, DateTimeKind.Utc).AddTicks(7212), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(267));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(270));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(273));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(274));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(281));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(4202));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(4210));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 27, 20, 15, 53, 386, DateTimeKind.Utc).AddTicks(4220));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9096), "" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9098), "" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9100), "" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9102), "" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9103), "" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9104), "" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9106), "" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9107), "" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastModifiedBy" },
                values: new object[] { new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9109), "" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1982));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1985));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5842));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5847));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5852));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5856));
        }
    }
}
