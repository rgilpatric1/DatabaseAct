using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTheWay.Web.Ui.Migrations
{
    public partial class ShippingContainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShippingContainer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Destination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingContainer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShippingContainer");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Students");
        }
    }
}
