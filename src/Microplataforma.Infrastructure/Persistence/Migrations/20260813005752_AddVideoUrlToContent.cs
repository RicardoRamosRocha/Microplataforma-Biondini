using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microplataforma.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddVideoUrlToContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Contents",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Contents");
        }
    }
}
