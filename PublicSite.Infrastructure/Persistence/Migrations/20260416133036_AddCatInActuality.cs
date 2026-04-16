using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSite.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCatInActuality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "News",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_ActualityCategories_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "ActualityCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_ActualityCategories_CategoryId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "News");
        }
    }
}
