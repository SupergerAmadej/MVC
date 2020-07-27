using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DSR_N2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Naslov = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvajalec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvajalec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vino",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Alkohol = table.Column<string>(nullable: true),
                    ProizvajalecId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vino_Proizvajalec_ProizvajalecId",
                        column: x => x.ProizvajalecId,
                        principalTable: "Proizvajalec",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dobava",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum_Nakupa = table.Column<DateTime>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    Cena = table.Column<double>(nullable: false),
                    VinoId = table.Column<int>(nullable: true),
                    KletId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dobava", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dobava_Klet_KletId",
                        column: x => x.KletId,
                        principalTable: "Klet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dobava_Vino_VinoId",
                        column: x => x.VinoId,
                        principalTable: "Vino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dobava_KletId",
                table: "Dobava",
                column: "KletId");

            migrationBuilder.CreateIndex(
                name: "IX_Dobava_VinoId",
                table: "Dobava",
                column: "VinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vino_ProizvajalecId",
                table: "Vino",
                column: "ProizvajalecId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dobava");

            migrationBuilder.DropTable(
                name: "Klet");

            migrationBuilder.DropTable(
                name: "Vino");

            migrationBuilder.DropTable(
                name: "Proizvajalec");
        }
    }
}
