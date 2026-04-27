using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSite.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_Type",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_Email",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TimelineItems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "TimelineItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Ressource_Url",
                table: "Images",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ressource_Name",
                table: "Images",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Images",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "ClubName",
                table: "Contacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "Contacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Contacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailBody",
                table: "Contacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MailSubject",
                table: "Contacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrganisationName",
                table: "Contacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Contacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "NewsLetters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsLetters");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "TimelineItems");

            migrationBuilder.DropColumn(
                name: "ClubName",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "MailBody",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "MailSubject",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OrganisationName",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Contacts");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TimelineItems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Ressource_Url",
                table: "Images",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Ressource_Name",
                table: "Images",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Images",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Type",
                table: "Images",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Email",
                table: "Contacts",
                column: "Email",
                unique: true);
        }
    }
}
