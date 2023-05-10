using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class i3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Identity",
                table: "ProjectImages");

            migrationBuilder.DropColumn(
                name: "Text",
                schema: "Identity",
                table: "ProjectImages");

            migrationBuilder.RenameColumn(
                name: "TitleMeeting",
                schema: "Identity",
                table: "Events",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Meeting",
                schema: "Identity",
                table: "Events",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "ProjectsId",
                schema: "Identity",
                table: "ProjectImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "Identity",
                table: "Events",
                newName: "TitleMeeting");

            migrationBuilder.RenameColumn(
                name: "Date",
                schema: "Identity",
                table: "Events",
                newName: "Meeting");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "ProjectImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Text",
                schema: "Identity",
                table: "ProjectImages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
