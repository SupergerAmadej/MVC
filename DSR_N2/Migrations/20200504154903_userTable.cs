using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DSR_N2.Migrations
{
    public partial class userTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Userri");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum_Roj",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Drzava",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "EMSO",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kraj_Roj",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Naslov",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Postna_Stevilka",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Priimek",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Starost",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datum_Roj",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Drzava",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EMSO",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Kraj_Roj",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Naslov",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Postna_Stevilka",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Priimek",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Starost",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "Userri",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum_Roj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drzava = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMSO = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kraj_Roj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postna_Stevilka = table.Column<int>(type: "int", nullable: false),
                    Priimek = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Starost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userri", x => x.id);
                });
        }
    }
}
