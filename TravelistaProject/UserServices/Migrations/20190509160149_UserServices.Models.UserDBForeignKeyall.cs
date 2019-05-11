using Microsoft.EntityFrameworkCore.Migrations;

namespace UserServices.Migrations
{
    public partial class UserServicesModelsUserDBForeignKeyall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_UserID",
                table: "UserFiles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookingDetails_UserID",
                table: "UserBookingDetails",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookingDetails_Users_UserID",
                table: "UserBookingDetails",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFiles_Users_UserID",
                table: "UserFiles",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBookingDetails_Users_UserID",
                table: "UserBookingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFiles_Users_UserID",
                table: "UserFiles");

            migrationBuilder.DropIndex(
                name: "IX_UserFiles_UserID",
                table: "UserFiles");

            migrationBuilder.DropIndex(
                name: "IX_UserBookingDetails_UserID",
                table: "UserBookingDetails");
        }
    }
}
