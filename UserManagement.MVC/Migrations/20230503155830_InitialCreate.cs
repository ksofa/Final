using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                schema: "Identity",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Projects",
                schema: "Identity",
                newName: "Project",
                newSchema: "Identity");

            migrationBuilder.AddColumn<int>(
                name: "NewsId",
                schema: "Identity",
                table: "Project",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                schema: "Identity",
                table: "Project",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Interior",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Interior_name = table.Column<string>(nullable: true),
                    InteriorPicture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interior", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Budget = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_News_NewsId",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Interior",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Report",
                schema: "Identity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_NewsId",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "NewsId",
                schema: "Identity",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "Project",
                schema: "Identity",
                newName: "Projects",
                newSchema: "Identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                schema: "Identity",
                table: "Projects",
                column: "Id");
        }
    }
}
