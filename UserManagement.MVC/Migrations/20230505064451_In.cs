using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class In : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Project_ProjectId",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ProjectId",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                schema: "Identity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                schema: "Identity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                schema: "Identity",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProjectsId",
                schema: "Identity",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "IconId",
                schema: "Identity",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "NewsPicture",
                schema: "Identity",
                table: "News",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ProjectsId",
                schema: "Identity",
                table: "Reports",
                column: "ProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Project_ProjectsId",
                schema: "Identity",
                table: "Reports",
                column: "ProjectsId",
                principalSchema: "Identity",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Project_ProjectsId",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ProjectsId",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProjectsId",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "IconId",
                schema: "Identity",
                table: "News");

            migrationBuilder.DropColumn(
                name: "NewsPicture",
                schema: "Identity",
                table: "News");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                schema: "Identity",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
