using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class ii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Project_ProjectsId",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "TotalArea",
                schema: "Identity",
                table: "Proposals",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Budget",
                schema: "Identity",
                table: "Proposals",
                newName: "Area");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectsId",
                schema: "Identity",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Price",
                schema: "Identity",
                table: "Project",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Area",
                schema: "Identity",
                table: "Project",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "TypeProject",
                schema: "Identity",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleMeeting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meeting = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_User_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ApplicationUserId",
                schema: "Identity",
                table: "Events",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Project_ProjectsId",
                schema: "Identity",
                table: "Reports",
                column: "ProjectsId",
                principalSchema: "Identity",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Project_ProjectsId",
                schema: "Identity",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "Identity");

            migrationBuilder.DropColumn(
                name: "TypeProject",
                schema: "Identity",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "Identity",
                table: "Proposals",
                newName: "TotalArea");

            migrationBuilder.RenameColumn(
                name: "Area",
                schema: "Identity",
                table: "Proposals",
                newName: "Budget");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectsId",
                schema: "Identity",
                table: "Reports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                schema: "Identity",
                table: "Project",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Area",
                schema: "Identity",
                table: "Project",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
    }
}
