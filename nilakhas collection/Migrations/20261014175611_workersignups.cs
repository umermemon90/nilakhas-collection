using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nilakhas_collection.Migrations
{
    /// <inheritdoc />
    public partial class workersignups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "workersignups",
                columns: table => new
                {
                    workerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workername = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    workerimagename = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workersignups", x => x.workerid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workersignups");
        }
    }
}
