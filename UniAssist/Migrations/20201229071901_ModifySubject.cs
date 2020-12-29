using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAssist.Migrations
{
    /// <inheritdoc />
    public partial class ModifySubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Subjects");

            migrationBuilder.AddColumn<int>(
                name: "Result",
                table: "Subjects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Subjects");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Subjects",
                type: "TEXT",
                nullable: true);
        }
    }
}
