using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CSS");

            migrationBuilder.CreateTable(
                name: "tblElanat",
                schema: "CSS",
                columns: table => new
                {
                    tblElanatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageTopic = table.Column<string>(maxLength: 1000, nullable: true),
                    MessageText = table.Column<string>(nullable: true),
                    DateFrom = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    DateTo = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    DisplayGroup = table.Column<string>(maxLength: 250, nullable: true),
                    LevelId = table.Column<int>(nullable: true),
                    FileUploadPath = table.Column<string>(maxLength: 250, nullable: true),
                    isShow = table.Column<bool>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblElanat", x => x.tblElanatId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblElanat",
                schema: "CSS");
        }
    }
}
