using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nilakhas_collection.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkerRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "workrole",
                table: "workersignups",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "workrole",
                table: "workersignups");
        }
    }
}
