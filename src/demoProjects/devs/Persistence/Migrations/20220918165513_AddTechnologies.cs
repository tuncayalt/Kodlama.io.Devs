using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddTechnologies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technologies_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "LanguageId", "Name" },
                values: new object[] { 1, 1, "ASP.NET" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "LanguageId", "Name" },
                values: new object[] { 2, 2, "Spring" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "LanguageId", "Name" },
                values: new object[] { 3, 1, "SignalR" });

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_LanguageId",
                table: "Technologies",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);
        }
    }
}
