using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nilakhas_collection.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adminlogins",
                columns: table => new
                {
                    loginid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    rememberMe = table.Column<bool>(type: "bit", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminlogins", x => x.loginid);
                });

            migrationBuilder.CreateTable(
                name: "createneworders",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ordernumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customername = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    bookingdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    diliverydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    orderstatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<int>(type: "int", nullable: false),
                    advanced = table.Column<int>(type: "int", nullable: false),
                    duepayment = table.Column<int>(type: "int", nullable: false),
                    lenght = table.Column<int>(type: "int", nullable: false),
                    chest = table.Column<int>(type: "int", nullable: false),
                    waist = table.Column<int>(type: "int", nullable: false),
                    bottom = table.Column<int>(type: "int", nullable: false),
                    shoulder = table.Column<int>(type: "int", nullable: false),
                    seelves = table.Column<int>(type: "int", nullable: false),
                    shalwar = table.Column<int>(type: "int", nullable: false),
                    shalwar_bottom = table.Column<int>(type: "int", nullable: false),
                    stitchingpackage = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    instruction = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_createneworders", x => x.orderid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminlogins");

            migrationBuilder.DropTable(
                name: "createneworders");
        }
    }
}
