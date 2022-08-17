using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeTrackerAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationTypeGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageDesiredMark = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationTypeGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationTypeGoals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EducationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calculation = table.Column<double>(type: "float", nullable: true),
                    EducationTypeGoalId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationTypes_EducationTypeGoals_EducationTypeGoalId",
                        column: x => x.EducationTypeGoalId,
                        principalTable: "EducationTypeGoals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompetenceAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weighting = table.Column<double>(type: "float", nullable: true),
                    EducationTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenceAreas_EducationTypes_EducationTypeId",
                        column: x => x.EducationTypeId,
                        principalTable: "EducationTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowOnDashboard = table.Column<bool>(type: "bit", nullable: true),
                    AverageDesiredMark = table.Column<double>(type: "float", nullable: true),
                    CompetenceAreaId = table.Column<int>(type: "int", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_CompetenceAreas_CompetenceAreaId",
                        column: x => x.CompetenceAreaId,
                        principalTable: "CompetenceAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Modules_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Modules_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<double>(type: "float", nullable: true),
                    Weighting = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModuleId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marks_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "EducationTypes",
                columns: new[] { "Id", "Calculation", "CreateBy", "CreatedAt", "EducationTypeGoalId", "IsActive", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 1.0, "", new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6182), null, true, new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6185), "", "Eidgenössisches Berufsattest (EBA)" },
                    { 2, 1.0, "", new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6188), null, true, new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6190), "", "Eidgenössisches Fachzertifikat (EFZ)" },
                    { 3, 1.0, "", new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6193), null, true, new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6195), "", "Berufsmatura (BMS)" },
                    { 4, 1.0, "", new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6197), null, true, new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6199), "", "IMS" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "IsActive", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(7725), true, new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(7738), "", "Roland Bucher" },
                    { 2, "", new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(7741), true, new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(7743), "", "Fritz Kempf" },
                    { 3, "", new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(7745), true, new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(7747), "", "Marcel Schorno" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "IsActive", "ModifiedAt", "ModifiedBy", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6004), true, new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6049), "", "1234qweR", "Evan" },
                    { 2, "", new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6053), true, new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6055), "", "1234qweR", "Apisana" },
                    { 3, "", new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6057), true, new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6059), "", "1234qweR", "Robert" }
                });

            migrationBuilder.InsertData(
                table: "CompetenceAreas",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "EducationTypeId", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "Weighting" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6214), 2, true, new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6216), "", "Fachkompetenzen", null },
                    { 2, "", new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6219), 3, true, new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6221), "", "Erweiterte Kompetenzen", null },
                    { 3, "", new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6223), 1, true, new DateTime(2022, 8, 17, 14, 32, 49, 566, DateTimeKind.Local).AddTicks(6225), "", "Allgemeinbildung", null }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "AverageDesiredMark", "CompetenceAreaId", "CreateBy", "CreatedAt", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ShowOnDashboard", "TeacherId", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, "", new DateTime(2022, 8, 17, 14, 32, 49, 567, DateTimeKind.Local).AddTicks(1298), true, new DateTime(2022, 8, 17, 14, 32, 49, 567, DateTimeKind.Local).AddTicks(1310), "", "INF 226B", true, 1, 3 },
                    { 2, null, null, "", new DateTime(2022, 8, 17, 14, 32, 49, 567, DateTimeKind.Local).AddTicks(1314), true, new DateTime(2022, 8, 17, 14, 32, 49, 567, DateTimeKind.Local).AddTicks(1316), "", "Mathematik", false, 2, 3 },
                    { 3, null, null, "", new DateTime(2022, 8, 17, 14, 32, 49, 567, DateTimeKind.Local).AddTicks(1319), true, new DateTime(2022, 8, 17, 14, 32, 49, 567, DateTimeKind.Local).AddTicks(1321), "", "Sprache und Kommunikation", false, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceAreas_EducationTypeId",
                table: "CompetenceAreas",
                column: "EducationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationTypeGoals_UserId",
                table: "EducationTypeGoals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationTypes_EducationTypeGoalId",
                table: "EducationTypes",
                column: "EducationTypeGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_ModuleId",
                table: "Marks",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CompetenceAreaId",
                table: "Modules",
                column: "CompetenceAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_TeacherId",
                table: "Modules",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_UserId",
                table: "Modules",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "CompetenceAreas");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "EducationTypes");

            migrationBuilder.DropTable(
                name: "EducationTypeGoals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
