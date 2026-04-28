using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSite.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateSponsor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SiteUrl",
                table: "Sponsors",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteUrl",
                table: "Sponsors");
        }
    }
}
