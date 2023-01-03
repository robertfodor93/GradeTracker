using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeTrackerAPI.Migrations
{
    public partial class createDiscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Marks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CompetenceAreas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(67), new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(69) });

            migrationBuilder.UpdateData(
                table: "CompetenceAreas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(74), new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(76) });

            migrationBuilder.UpdateData(
                table: "CompetenceAreas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(78), new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(79) });

            migrationBuilder.UpdateData(
                table: "EducationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 9, 9, 13, 54, 51, 224, DateTimeKind.Local).AddTicks(9889), new DateTime(2022, 9, 9, 13, 54, 51, 224, DateTimeKind.Local).AddTicks(9935) });

            migrationBuilder.UpdateData(
                table: "EducationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 9, 9, 13, 54, 51, 224, DateTimeKind.Local).AddTicks(9941), new DateTime(2022, 9, 9, 13, 54, 51, 224, DateTimeKind.Local).AddTicks(9942) });

            migrationBuilder.UpdateData(
                table: "EducationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 9, 9, 13, 54, 51, 224, DateTimeKind.Local).AddTicks(9945), new DateTime(2022, 9, 9, 13, 54, 51, 224, DateTimeKind.Local).AddTicks(9946) });

            migrationBuilder.UpdateData(
                table: "EducationTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 9, 9, 13, 54, 51, 224, DateTimeKind.Local).AddTicks(9948), new DateTime(2022, 9, 9, 13, 54, 51, 224, DateTimeKind.Local).AddTicks(9950) });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(3531), new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(3542) });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(3546), new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(3550), new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(3551) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(1298), new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(1313), new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(1314) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(1316), new DateTime(2022, 9, 9, 13, 54, 51, 225, DateTimeKind.Local).AddTicks(1318) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Marks");

            migrationBuilder.UpdateData(
                table: "CompetenceAreas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(2101), new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(2105) });

            migrationBuilder.UpdateData(
                table: "CompetenceAreas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(2214), new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(2217) });

            migrationBuilder.UpdateData(
                table: "CompetenceAreas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(2220), new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(2222) });

            migrationBuilder.UpdateData(
                table: "EducationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(1921), new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(1966) });

            migrationBuilder.UpdateData(
                table: "EducationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(1970), new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(1972) });

            migrationBuilder.UpdateData(
                table: "EducationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(1974), new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(1976) });

            migrationBuilder.UpdateData(
                table: "EducationTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(1979), new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(1981) });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(6577), new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(6591) });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(6595), new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(6597) });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(6600), new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(6602) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(3603), new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(3619) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(3623), new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(3625) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(3627), new DateTime(2022, 8, 18, 15, 52, 11, 359, DateTimeKind.Local).AddTicks(3629) });
        }
    }
}
