using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftoffProj.Data.Migrations
{
    public partial class UpdatedPostClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostID",
                table: "Paints",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paints_PostID",
                table: "Paints",
                column: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Paints_Posts_PostID",
                table: "Paints",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paints_Posts_PostID",
                table: "Paints");

            migrationBuilder.DropIndex(
                name: "IX_Paints_PostID",
                table: "Paints");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "Paints");
        }
    }
}
