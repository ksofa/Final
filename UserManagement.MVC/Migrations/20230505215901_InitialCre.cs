using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class InitialCre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconId",
                schema: "Identity",
                table: "News");

            migrationBuilder.DropColumn(
                name: "NewsPicture",
                schema: "Identity",
                table: "News");

            migrationBuilder.DropColumn(
                name: "InteriorPicture",
                schema: "Identity",
                table: "Interior");

            migrationBuilder.RenameColumn(
                name: "Interior_name",
                schema: "Identity",
                table: "Interior",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "ProjectImages",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeProject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalArea = table.Column<long>(type: "bigint", nullable: false),
                    Budget = table.Column<long>(type: "bigint", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectImages",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Proposals",
                schema: "Identity");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Identity",
                table: "Interior",
                newName: "Interior_name");

            migrationBuilder.AddColumn<byte[]>(
                name: "IconId",
                schema: "Identity",
                table: "News",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "NewsPicture",
                schema: "Identity",
                table: "News",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "InteriorPicture",
                schema: "Identity",
                table: "Interior",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
