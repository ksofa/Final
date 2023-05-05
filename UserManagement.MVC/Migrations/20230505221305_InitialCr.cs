using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class InitialCr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "Identity",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUsersId",
                schema: "Identity",
                table: "Project",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "Identity",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_ApplicationUsersId",
                schema: "Identity",
                table: "Project",
                column: "ApplicationUsersId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_ApplicationUsersId",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ApplicationUsersId",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ApplicationUsersId",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "Identity",
                table: "News");
        }
    }
}
