using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeTrackerAPI.Migrations
{
    public partial class SeedingInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EducationTypes",
                columns: new[] { "Id", "Calculation", "CreateBy", "CreatedAt", "EducationTypeGoalId", "IsActive", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 1.0, "", new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1247), null, true, new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1251), "", "Eidgenössisches Berufsattest (EBA)" },
                    { 2, 1.0, "", new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1257), null, true, new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1259), "", "Eidgenössisches Fachzertifikat (EFZ)" },
                    { 3, 1.0, "", new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1263), null, true, new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1266), "", "Berufsmatura (BMS)" },
                    { 4, 1.0, "", new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1269), null, true, new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1272), "", "IMS" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "IsActive", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(3270), true, new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(3291), "", "Roland Bucher" },
                    { 2, "", new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(3296), true, new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(3299), "", "Fritz Kempf" },
                    { 3, "", new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(3302), true, new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(3305), "", "Marcel Schorno" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1016), new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1075), new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1082), new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1085) });

            migrationBuilder.InsertData(
                table: "CompetenceAreas",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "EducationTypeId", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "Weighting" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1300), 2, true, new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1304), "", "Fachkompetenzen", null },
                    { 2, "", new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1308), 3, true, new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1311), "", "Erweiterte Kompetenzen", null },
                    { 3, "", new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1315), 1, true, new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(1317), "", "Allgemeinbildung", null }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "AverageDesiredMark", "CompetenceAreaId", "CreateBy", "CreatedAt", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ShowOnDashboard", "TeacherId", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, "", new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(9129), true, new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(9151), "", "INF 226B", true, 1, 3 },
                    { 2, null, null, "", new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(9158), true, new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(9161), "", "Mathematik", false, 2, 3 },
                    { 3, null, null, "", new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(9165), true, new DateTime(2022, 8, 17, 13, 6, 11, 847, DateTimeKind.Local).AddTicks(9167), "", "Sprache und Kommunikation", false, 3, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CompetenceAreas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CompetenceAreas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CompetenceAreas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EducationTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EducationTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EducationTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EducationTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 16, 15, 40, 50, 744, DateTimeKind.Local).AddTicks(2842), new DateTime(2022, 8, 16, 15, 40, 50, 744, DateTimeKind.Local).AddTicks(2918) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 16, 15, 40, 50, 744, DateTimeKind.Local).AddTicks(2921), new DateTime(2022, 8, 16, 15, 40, 50, 744, DateTimeKind.Local).AddTicks(2923) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 8, 16, 15, 40, 50, 744, DateTimeKind.Local).AddTicks(2925), new DateTime(2022, 8, 16, 15, 40, 50, 744, DateTimeKind.Local).AddTicks(2926) });
        }
    }
}
