using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardTrader.Infrastructure.Migrations
{
    public partial class NullableCollectionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BinderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WantedListId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "WantedListId",
                table: "AspNetUsers",
                type: "nvarchar(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(36)");

            migrationBuilder.AlterColumn<string>(
                name: "BinderId",
                table: "AspNetUsers",
                type: "nvarchar(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(36)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BinderId",
                table: "AspNetUsers",
                column: "BinderId",
                unique: true,
                filter: "[BinderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WantedListId",
                table: "AspNetUsers",
                column: "WantedListId",
                unique: true,
                filter: "[WantedListId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BinderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WantedListId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "WantedListId",
                table: "AspNetUsers",
                type: "nvarchar(36)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BinderId",
                table: "AspNetUsers",
                type: "nvarchar(36)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BinderId",
                table: "AspNetUsers",
                column: "BinderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WantedListId",
                table: "AspNetUsers",
                column: "WantedListId",
                unique: true);
        }
    }
}
