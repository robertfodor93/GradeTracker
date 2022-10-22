using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeTrackerAPI.Migrations
{
    public partial class InitialCreation : Migration
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
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
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
                values: new object[,]
                {
                    { 1, 1.0, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3506), true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3552), "", "EFZ" },
                    { 2, 1.0, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3558), true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3560), "", "BM" },
                    { 3, 1.0, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3563), true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3565), "", "MS" }
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4fec0ca6-24a3-4815-8b47-b75e56d645ff", "a87878be-10fe-42f5-9d3f-ee401cf02cbc", "Administrator", "ADMINISTRATOR" },
                    { "a5fd9f22-4f33-4981-964b-574f7c2f159c", "5f5dd8f4-c3f1-460c-8ccf-26ebabefae6c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "CompetenceAreas",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "EducationTypeId", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "Weighting" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3588), 1, true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3591), "", "Fachkompetenzen", null },
                    { 2, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3594), 1, true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3596), "", "Erweiterte Grundkompetenzen", null },
                    { 3, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3599), 1, true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3601), "", "Allgemeinbildung", null },
                    { 4, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3604), 1, true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3606), "", "ÜK", null },
                    { 5, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3609), 2, true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3611), "", "Erweiterte Grundkompetenzen", null },
                    { 6, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3614), 2, true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3616), "", "Erweiterte Allgemeinbildung", null },
                    { 7, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3618), 2, true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3620), "", "ÜK", null },
                    { 8, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3623), 3, true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3625), "", "Fachkompetenzen", null },
                    { 9, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3628), 3, true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3630), "", "Erweiterte Grundkompetenzen", null },
                    { 10, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3632), 3, true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3635), "", "Erweiterte Allgemeinbildung", null },
                    { 11, "", new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3637), 3, true, new DateTime(2022, 10, 21, 15, 24, 52, 893, DateTimeKind.Local).AddTicks(3639), "", "ÜK", null }
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
                name: "IdentityRole");

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
