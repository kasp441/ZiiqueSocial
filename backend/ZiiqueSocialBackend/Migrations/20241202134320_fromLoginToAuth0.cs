using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZiiqueSocialBackend.Migrations
{
    /// <inheritdoc />
    public partial class fromLoginToAuth0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Logins_LoginId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_LoginId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "authId",
                table: "Profiles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "authId",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "Profiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<byte[]>(type: "bytea", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_LoginId",
                table: "Profiles",
                column: "LoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Logins_LoginId",
                table: "Profiles",
                column: "LoginId",
                principalTable: "Logins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
