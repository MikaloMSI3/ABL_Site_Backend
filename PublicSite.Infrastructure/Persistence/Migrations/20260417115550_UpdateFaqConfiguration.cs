using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSite.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFaqConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_FAQs_FAQCategories_FaqCategoryId",
                table: "FAQs",
                column: "FaqCategoryId",
                principalTable: "FAQCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FAQs_FAQCategories_FaqCategoryId",
                table: "FAQs");
        }
    }
}
