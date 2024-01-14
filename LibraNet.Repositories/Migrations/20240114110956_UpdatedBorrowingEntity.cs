using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraNet.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBorrowingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedAt",
                table: "Borrowing",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosedAt",
                table: "Borrowing");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Books",
                type: "INTEGER",
                nullable: true);
        }
    }
}
