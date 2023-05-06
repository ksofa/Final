using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class Initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_ApplicationUsersId",
                schema: "Identity",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "ApplicationUsersId",
                schema: "Identity",
                table: "Project",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ApplicationUsersId",
                schema: "Identity",
                table: "Project",
                newName: "IX_Project_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_ApplicationUserId",
                schema: "Identity",
                table: "Project",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_ApplicationUserId",
                schema: "Identity",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Project",
                newName: "ApplicationUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ApplicationUserId",
                schema: "Identity",
                table: "Project",
                newName: "IX_Project_ApplicationUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_ApplicationUsersId",
                schema: "Identity",
                table: "Project",
                column: "ApplicationUsersId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
