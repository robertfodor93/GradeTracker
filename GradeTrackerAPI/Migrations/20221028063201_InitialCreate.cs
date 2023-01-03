using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeTrackerAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calculation = table.Column<double>(type: "float", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationTypes", x => x.Id);
                });

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
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "EducationTypeGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageDesiredMark = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    EducationTypeId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_EducationTypeGoals_EducationTypes_EducationTypeId",
                        column: x => x.EducationTypeId,
                        principalTable: "EducationTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EducationTypeGoals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                    TeacherId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weighting = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EducationTypes",
                columns: new[] { "Id", "Calculation", "CreateBy", "CreatedAt", "IsActive", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[] { 1, 1.0, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8453), true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8514), "", "EFZ" });

            migrationBuilder.InsertData(
                table: "EducationTypes",
                columns: new[] { "Id", "Calculation", "CreateBy", "CreatedAt", "IsActive", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[] { 2, 1.0, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8546), true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8554), "", "BM" });

            migrationBuilder.InsertData(
                table: "EducationTypes",
                columns: new[] { "Id", "Calculation", "CreateBy", "CreatedAt", "IsActive", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[] { 3, 1.0, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8558), true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8562), "", "MS" });

            migrationBuilder.InsertData(
                table: "CompetenceAreas",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "EducationTypeId", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "Weighting" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8898), 1, true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8912), "", "Fachkompetenzen", null },
                    { 2, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8916), 1, true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8918), "", "Erweiterte Grundkompetenzen", null },
                    { 3, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8920), 1, true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8922), "", "Allgemeinbildung", null },
                    { 4, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8925), 1, true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8927), "", "ÜK", null },
                    { 5, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8929), 2, true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8931), "", "Erweiterte Grundkompetenzen", null },
                    { 6, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8933), 2, true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8935), "", "Erweiterte Allgemeinbildung", null },
                    { 7, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8938), 2, true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8940), "", "ÜK", null },
                    { 8, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8942), 3, true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8944), "", "Fachkompetenzen", null },
                    { 9, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8947), 3, true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8949), "", "Erweiterte Grundkompetenzen", null },
                    { 10, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8951), 3, true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8953), "", "Erweiterte Allgemeinbildung", null },
                    { 11, "", new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8956), 3, true, new DateTime(2022, 10, 28, 8, 32, 0, 730, DateTimeKind.Local).AddTicks(8958), "", "ÜK", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceAreas_EducationTypeId",
                table: "CompetenceAreas",
                column: "EducationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationTypeGoals_EducationTypeId",
                table: "EducationTypeGoals",
                column: "EducationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationTypeGoals_UserId",
                table: "EducationTypeGoals",
                column: "UserId");

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
                name: "EducationTypeGoals");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "CompetenceAreas");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EducationTypes");
        }
    }
}
