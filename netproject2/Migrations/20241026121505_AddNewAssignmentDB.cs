using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace netproject2.Migrations
{
    /// <inheritdoc />
    public partial class AddNewAssignmentDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AssignmentType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DueDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AssignmentValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AssignmentResult = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_Assignments_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentID", "AssignmentResult", "AssignmentType", "AssignmentValue", "Description", "DueDate", "SubjectId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 0.0m, "Homework", 10.0m, "indiviudal report", new DateTime(2024, 11, 2, 23, 15, 5, 533, DateTimeKind.Local).AddTicks(1326), 1, "Assignment1: report", 1 },
                    { 2, 0.0m, "Lab Report", 20.0m, "Write a report on the mechanics lab", new DateTime(2024, 11, 5, 23, 15, 5, 533, DateTimeKind.Local).AddTicks(1419), 2, "Assignment2: group report", 1 },
                    { 3, 0.0m, "Research Paper", 30.0m, "Research on organic compounds and submit a paper", new DateTime(2024, 11, 9, 23, 15, 5, 533, DateTimeKind.Local).AddTicks(1424), 3, "Organic Chemistry Research", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "FullName",
                value: "John Doe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "FullName",
                value: "Jane Smith");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_SubjectId",
                table: "Assignments",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");
        }
    }
}
