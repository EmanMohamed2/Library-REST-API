using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddDateWriting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadLine",
                table: "Reviews");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateWriting",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateWriting",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "HeadLine",
                table: "Reviews",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
