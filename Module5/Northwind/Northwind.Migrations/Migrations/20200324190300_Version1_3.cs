using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Northwind.Migrations.Migrations
{
    public partial class Version1_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EstablishmentDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.RenameTable(
                name: "Region",
                newName: "Regions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstablishmentDate",
                table: "Customers");

            migrationBuilder.RenameTable(
                  name: "Regions",
                  newName: "Region");
        }
    }
}
