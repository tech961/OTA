using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rs.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_BrithDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                schema: "Pet",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "BirthYear",
                schema: "Pet",
                table: "Pets",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthYear",
                schema: "Pet",
                table: "Pets");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                schema: "Pet",
                table: "Pets",
                type: "datetime2",
                nullable: true);
        }
    }
}
