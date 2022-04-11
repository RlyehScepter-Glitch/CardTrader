using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardTrader.Infrastructure.Migrations
{
    public partial class CommentUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorName",
                table: "ForumComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorName",
                table: "ForumComments");
        }
    }
}
