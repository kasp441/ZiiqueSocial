using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZiiqueSocialBackend.Migrations
{
    /// <inheritdoc />
    public partial class added_visibility_on_posts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "Posts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Posts");
        }
    }
}
