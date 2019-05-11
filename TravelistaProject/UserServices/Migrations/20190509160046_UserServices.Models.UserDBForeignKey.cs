using Microsoft.EntityFrameworkCore.Migrations;

namespace UserServices.Migrations
{
    public partial class UserServicesModelsUserDBForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserAdditionalInfo_UserID",
                table: "UserAdditionalInfo",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdditionalInfo_Users_UserID",
                table: "UserAdditionalInfo",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAdditionalInfo_Users_UserID",
                table: "UserAdditionalInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserAdditionalInfo_UserID",
                table: "UserAdditionalInfo");
        }
    }
}
