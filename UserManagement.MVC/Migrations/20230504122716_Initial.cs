using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                schema: "Identity",
                table: "Report");

            migrationBuilder.RenameTable(
                name: "Report",
                schema: "Identity",
                newName: "Reports",
                newSchema: "Identity");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Project",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                schema: "Identity",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "Identity",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "News",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Reports",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                schema: "Identity",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                schema: "Identity",
                table: "Reports",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ProjectId",
                schema: "Identity",
                table: "Reports",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Project_ProjectId",
                schema: "Identity",
                table: "Reports",
                column: "ProjectId",
                principalSchema: "Identity",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Project_ProjectId",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ProjectId",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Identity",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Identity",
                table: "News");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.RenameTable(
                name: "Reports",
                schema: "Identity",
                newName: "Report",
                newSchema: "Identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                schema: "Identity",
                table: "Report",
                column: "Id");
        }
    }
}
