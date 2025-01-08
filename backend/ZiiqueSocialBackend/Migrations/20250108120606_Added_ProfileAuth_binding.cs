using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZiiqueSocialBackend.Migrations
{
    /// <inheritdoc />
    public partial class Added_ProfileAuth_binding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_ProfileAuths_Guid",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "ProfileAuths");
        }
    }
}
