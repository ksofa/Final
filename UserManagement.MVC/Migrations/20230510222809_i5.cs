using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class i5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImages_Project_ProjectsId",
                schema: "Identity",
                table: "ProjectImages");

            migrationBuilder.DropIndex(
                name: "IX_ProjectImages_ProjectsId",
                schema: "Identity",
                table: "ProjectImages");

            migrationBuilder.DropColumn(
                name: "ProjectsId",
                schema: "Identity",
                table: "ProjectImages");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "ProjectImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Identity",
                table: "ProjectImages");

            migrationBuilder.AddColumn<int>(
                name: "ProjectsId",
                schema: "Identity",
                table: "ProjectImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImages_ProjectsId",
                schema: "Identity",
                table: "ProjectImages",
                column: "ProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImages_Project_ProjectsId",
                schema: "Identity",
                table: "ProjectImages",
                column: "ProjectsId",
                principalSchema: "Identity",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
