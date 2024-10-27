using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netproject2.Migrations
{
    public partial class AddSubjectIdToSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add SubjectId column (if not already present)
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Subjects",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");  // Ensure auto-increment for SubjectId

            // Set SubjectId as the primary key
            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key and SubjectId column if rolling back the migration
            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Subjects");
        }
    }
}
