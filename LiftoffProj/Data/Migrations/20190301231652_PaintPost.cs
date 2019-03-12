using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftoffProj.Data.Migrations
{
    public partial class PaintPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "PaintPost",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostID = table.Column<int>(nullable: false),
                    PaintID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintPost", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaintPost_Paints_PaintID",
                        column: x => x.PaintID,
                        principalTable: "Paints",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaintPost_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaintPost_PaintID",
                table: "PaintPost",
                column: "PaintID");

            migrationBuilder.CreateIndex(
                name: "IX_PaintPost_PostID",
                table: "PaintPost",
                column: "PostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaintPost");

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
    }
}
