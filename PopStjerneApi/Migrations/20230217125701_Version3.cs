using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PopStjerneApi.Migrations
{
    /// <inheritdoc />
    public partial class Version3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Artist",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "Artist",
                newName: "ArtistName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Artist",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ArtistName",
                table: "Artist",
                newName: "Biography");
        }
    }
}
