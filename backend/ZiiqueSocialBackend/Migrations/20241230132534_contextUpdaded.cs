using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZiiqueSocialBackend.Migrations
{
    /// <inheritdoc />
    public partial class contextUpdaded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "authId",
                table: "Profiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "authId",
                table: "Profiles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
