using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PopStjerneApi.Migrations
{
    /// <inheritdoc />
    public partial class Version2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateOfBirth",
                table: "Artist");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfBirth",
                table: "Artist",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
