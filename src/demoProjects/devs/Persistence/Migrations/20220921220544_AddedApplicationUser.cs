using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(512)", maxLength: 512, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(512)", maxLength: 512, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GitHubAddress = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Language.Add" },
                    { 2, "Language.Update" },
                    { 3, "Language.Delete" },
                    { 4, "Technology.Add" },
                    { 5, "Technology.Update" },
                    { 6, "Technology.Delete" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { 1, 1, "tuncayalt@gmail.com", "Tuncay", "Altinpulluk", new byte[] { 118, 66, 130, 65, 26, 251, 61, 126, 205, 202, 210, 152, 27, 227, 38, 91, 211, 25, 225, 193, 57, 133, 234, 22, 103, 247, 215, 121, 98, 161, 108, 59, 36, 224, 228, 166, 65, 9, 240, 30, 185, 83, 220, 73, 57, 182, 96, 120, 89, 6, 253, 81, 59, 25, 200, 90, 125, 203, 143, 35, 95, 219, 71, 20 }, new byte[] { 23, 177, 64, 71, 17, 126, 213, 58, 47, 57, 54, 232, 159, 94, 204, 62, 57, 138, 88, 110, 92, 242, 51, 72, 178, 64, 168, 128, 254, 60, 150, 239, 162, 3, 188, 14, 240, 170, 106, 197, 245, 70, 111, 124, 47, 39, 247, 222, 139, 70, 78, 151, 115, 228, 158, 15, 133, 176, 137, 114, 89, 213, 122, 64, 147, 2, 125, 197, 123, 42, 110, 158, 248, 95, 48, 144, 132, 116, 59, 116, 203, 243, 240, 67, 107, 11, 24, 91, 68, 180, 229, 192, 12, 55, 210, 197, 47, 214, 43, 47, 102, 131, 121, 112, 184, 210, 163, 84, 40, 21, 77, 204, 176, 140, 224, 27, 219, 76, 139, 120, 82, 76, 198, 139, 139, 138, 172, 42 }, true });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "GitHubAddress", "UserId" },
                values: new object[] { 1, "https://github.com/tuncayalt", 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_UserId",
                table: "ApplicationUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
