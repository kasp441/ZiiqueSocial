using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZiiqueSocialBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedFollows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfileGuid",
                table: "Profiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfileGuid",
                table: "Profiles",
                column: "ProfileGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Profiles_ProfileGuid",
                table: "Profiles",
                column: "ProfileGuid",
                principalTable: "Profiles",
                principalColumn: "Guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Profiles_ProfileGuid",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ProfileGuid",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileGuid",
                table: "Profiles");
        }
    }
}
