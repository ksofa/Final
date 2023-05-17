using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class i4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImages_Project_ProjectsId",
                schema: "Identity",
                table: "ProjectImages");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectsId",
                schema: "Identity",
                table: "ProjectImages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImages_Project_ProjectsId",
                schema: "Identity",
                table: "ProjectImages");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectsId",
                schema: "Identity",
                table: "ProjectImages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
