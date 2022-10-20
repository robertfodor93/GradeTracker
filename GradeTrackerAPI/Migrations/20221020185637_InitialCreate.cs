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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationTypeGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageDesiredMark = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                        name: "FK_EducationTypeGoals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                        name: "FK_Modules_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0961fd30-cd0b-423b-ae89-c342ae97f0cd", "41ee31ae-346c-4458-8d3e-397a4d822985", "Administrator", "ADMINISTRATOR" },
                    { "8c092364-6896-41c2-91bc-9f039234bf8a", "911f70c7-226d-4a87-bb2d-c503d49079fb", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "EducationTypes",
                columns: new[] { "Id", "Calculation", "CreateBy", "CreatedAt", "EducationTypeGoalId", "IsActive", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 1.0, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5326), null, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5354), "", "EFZ" },
                    { 2, 1.0, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5357), null, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5358), "", "BM" },
                    { 3, 1.0, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5360), null, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5361), "", "MS" }
                });

            migrationBuilder.InsertData(
                table: "CompetenceAreas",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "EducationTypeId", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "Weighting" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5376), 1, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5377), "", "Fachkompetenzen", null },
                    { 2, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5379), 1, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5381), "", "Erweiterte Grundkompetenzen", null },
                    { 3, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5382), 1, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5384), "", "Allgemeinbildung", null },
                    { 4, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5385), 1, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5386), "", "ÜK", null },
                    { 5, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5388), 2, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5389), "", "Erweiterte Grundkompetenzen", null },
                    { 6, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5391), 2, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5392), "", "Erweiterte Allgemeinbildung", null },
                    { 7, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5393), 2, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5395), "", "ÜK", null },
                    { 8, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5396), 3, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5397), "", "Fachkompetenzen", null },
                    { 9, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5399), 3, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5400), "", "Erweiterte Grundkompetenzen", null },
                    { 10, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5402), 3, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5403), "", "Erweiterte Allgemeinbildung", null },
                    { 11, "", new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5404), 3, true, new DateTime(2022, 10, 20, 20, 56, 37, 491, DateTimeKind.Local).AddTicks(5406), "", "ÜK", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
                name: "AspNetUsers");
        }
    }
}
