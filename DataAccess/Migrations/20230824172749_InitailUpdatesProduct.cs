using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitailUpdatesProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderss_users_UserId",
                table: "Orderss");

            migrationBuilder.AddColumn<string>(
                name: "LangCode",
                table: "ProductLanguages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orderss",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "CategoryLanguages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLanguages_ProductId",
                table: "CategoryLanguages",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLanguages_Products_ProductId",
                table: "CategoryLanguages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderss_users_UserId",
                table: "Orderss",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLanguages_Products_ProductId",
                table: "CategoryLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderss_users_UserId",
                table: "Orderss");

            migrationBuilder.DropIndex(
                name: "IX_CategoryLanguages_ProductId",
                table: "CategoryLanguages");

            migrationBuilder.DropColumn(
                name: "LangCode",
                table: "ProductLanguages");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CategoryLanguages");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orderss",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderss_users_UserId",
                table: "Orderss",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
