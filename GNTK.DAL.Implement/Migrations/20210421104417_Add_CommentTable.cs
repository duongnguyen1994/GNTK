using Microsoft.EntityFrameworkCore.Migrations;

namespace GNTK.DAL.Implement.Migrations
{
    public partial class Add_CommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<string>(maxLength: 450, nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CommentId",
                table: "Bookings",
                column: "CommentId",
                unique: true,
                filter: "[CommentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Comments_CommentId",
                table: "Bookings",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Comments_CommentId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CommentId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Bookings");
        }
    }
}
