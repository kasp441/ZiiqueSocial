using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZiiqueSocialBackend.Migrations
{
    /// <inheritdoc />
    public partial class Removed_profileauth_object : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_ProfileAuths_Guid",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "ProfileAuths");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthId",
                table: "Profiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthId",
                table: "Profiles");

            migrationBuilder.CreateTable(
                name: "ProfileAuths",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileAuths", x => x.ProfileId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ProfileAuths_Guid",
                table: "Profiles",
                column: "Guid",
                principalTable: "ProfileAuths",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
