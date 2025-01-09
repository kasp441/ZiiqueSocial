using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZiiqueSocialBackend.Migrations
{
    /// <inheritdoc />
    public partial class changedfollowing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Profiles_followsGuid",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Profiles_profileGuid",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_followsGuid",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_profileGuid",
                table: "Follows");

            migrationBuilder.RenameColumn(
                name: "profileGuid",
                table: "Follows",
                newName: "profile");

            migrationBuilder.RenameColumn(
                name: "followsGuid",
                table: "Follows",
                newName: "follows");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profile",
                table: "Follows",
                newName: "profileGuid");

            migrationBuilder.RenameColumn(
                name: "follows",
                table: "Follows",
                newName: "followsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_followsGuid",
                table: "Follows",
                column: "followsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_profileGuid",
                table: "Follows",
                column: "profileGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Profiles_followsGuid",
                table: "Follows",
                column: "followsGuid",
                principalTable: "Profiles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Profiles_profileGuid",
                table: "Follows",
                column: "profileGuid",
                principalTable: "Profiles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
