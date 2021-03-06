using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryMicroservice.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SciPapersPublished",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SciPaperAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SciPaperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SciPapersPublished", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SciPapersPublished");
        }
    }
}
