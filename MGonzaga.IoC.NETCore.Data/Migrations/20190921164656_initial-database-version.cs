using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MGonzaga.IoC.NETCore.Data.Migrations
{
    public partial class initialdatabaseversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UniqueId = table.Column<Guid>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ObjectId = table.Column<int>(nullable: false),
                    UsedLink = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ConfirmedEmail = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false),
                    LoginLastDate = table.Column<DateTime>(nullable: true),
                    LoginAttempts = table.Column<int>(nullable: false),
                    UniqueId = table.Column<Guid>(nullable: true),
                    Locale = table.Column<string>(nullable: true),
                    OAuthProvider = table.Column<int>(nullable: false),
                    OAuthUId = table.Column<string>(nullable: true),
                    RolesNames = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
