using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduCraft.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameExpertiseToCompetenceName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Expertise",
                table: "Competences",
                newName: "CompetenceName");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Competences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Competences",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Competences");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Competences");

            migrationBuilder.RenameColumn(
                name: "CompetenceName",
                table: "Competences",
                newName: "Expertise");
        }
    }
}
