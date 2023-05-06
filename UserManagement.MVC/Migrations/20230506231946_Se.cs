using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class Se : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_ApplicationUserId",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ApplicationUserId",
                schema: "Identity",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                schema: "Identity",
                table: "Project",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_ApplicationUserId1",
                schema: "Identity",
                table: "Project",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_ApplicationUserId1",
                schema: "Identity",
                table: "Project",
                column: "ApplicationUserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_ApplicationUserId1",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ApplicationUserId1",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                schema: "Identity",
                table: "Project");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Project",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ApplicationUserId",
                schema: "Identity",
                table: "Project",
                column: "ApplicationUserId");

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
    }
}
