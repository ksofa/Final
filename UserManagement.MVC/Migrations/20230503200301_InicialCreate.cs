using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_News_NewsId",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_NewsId",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Budget",
                schema: "Identity",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Identity",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "Text",
                schema: "Identity",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "NewsId",
                schema: "Identity",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "ReportText",
                schema: "Identity",
                table: "Report",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportText",
                schema: "Identity",
                table: "Report");

            migrationBuilder.AddColumn<int>(
                name: "Budget",
                schema: "Identity",
                table: "Report",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "Identity",
                table: "Report",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                schema: "Identity",
                table: "Report",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewsId",
                schema: "Identity",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_NewsId",
                schema: "Identity",
                table: "Project",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_News_NewsId",
                schema: "Identity",
                table: "Project",
                column: "NewsId",
                principalSchema: "Identity",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
