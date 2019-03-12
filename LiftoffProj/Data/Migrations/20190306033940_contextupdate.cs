using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftoffProj.Data.Migrations
{
    public partial class contextupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaintPost_Paints_PaintID",
                table: "PaintPost");

            migrationBuilder.DropForeignKey(
                name: "FK_PaintPost_Posts_PostID",
                table: "PaintPost");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLink_Posts_PostID",
                table: "PostLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostLink",
                table: "PostLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaintPost",
                table: "PaintPost");

            migrationBuilder.RenameTable(
                name: "PostLink",
                newName: "PostLinks");

            migrationBuilder.RenameTable(
                name: "PaintPost",
                newName: "PaintPosts");

            migrationBuilder.RenameIndex(
                name: "IX_PostLink_PostID",
                table: "PostLinks",
                newName: "IX_PostLinks_PostID");

            migrationBuilder.RenameIndex(
                name: "IX_PaintPost_PostID",
                table: "PaintPosts",
                newName: "IX_PaintPosts_PostID");

            migrationBuilder.RenameIndex(
                name: "IX_PaintPost_PaintID",
                table: "PaintPosts",
                newName: "IX_PaintPosts_PaintID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostLinks",
                table: "PostLinks",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaintPosts",
                table: "PaintPosts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PaintPosts_Paints_PaintID",
                table: "PaintPosts",
                column: "PaintID",
                principalTable: "Paints",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaintPosts_Posts_PostID",
                table: "PaintPosts",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLinks_Posts_PostID",
                table: "PostLinks",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaintPosts_Paints_PaintID",
                table: "PaintPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_PaintPosts_Posts_PostID",
                table: "PaintPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLinks_Posts_PostID",
                table: "PostLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostLinks",
                table: "PostLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaintPosts",
                table: "PaintPosts");

            migrationBuilder.RenameTable(
                name: "PostLinks",
                newName: "PostLink");

            migrationBuilder.RenameTable(
                name: "PaintPosts",
                newName: "PaintPost");

            migrationBuilder.RenameIndex(
                name: "IX_PostLinks_PostID",
                table: "PostLink",
                newName: "IX_PostLink_PostID");

            migrationBuilder.RenameIndex(
                name: "IX_PaintPosts_PostID",
                table: "PaintPost",
                newName: "IX_PaintPost_PostID");

            migrationBuilder.RenameIndex(
                name: "IX_PaintPosts_PaintID",
                table: "PaintPost",
                newName: "IX_PaintPost_PaintID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostLink",
                table: "PostLink",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaintPost",
                table: "PaintPost",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PaintPost_Paints_PaintID",
                table: "PaintPost",
                column: "PaintID",
                principalTable: "Paints",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaintPost_Posts_PostID",
                table: "PaintPost",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLink_Posts_PostID",
                table: "PostLink",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
