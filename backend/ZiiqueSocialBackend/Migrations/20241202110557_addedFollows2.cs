using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZiiqueSocialBackend.Migrations
{
    /// <inheritdoc />
    public partial class addedFollows2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    profileGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    followsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follows_Profiles_followsGuid",
                        column: x => x.followsGuid,
                        principalTable: "Profiles",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Follows_Profiles_profileGuid",
                        column: x => x.profileGuid,
                        principalTable: "Profiles",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Follows_followsGuid",
                table: "Follows",
                column: "followsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_profileGuid",
                table: "Follows",
                column: "profileGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Follows");

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
    }
}
