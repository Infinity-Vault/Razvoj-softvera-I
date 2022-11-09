using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Example.Migrations
{
    public partial class kreiranje_baze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Predmeti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ECTS = table.Column<int>(type: "int", nullable: false),
                    OcjenaPredmeta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmeti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Opstina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drzava_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstina", x => x.id);
                    table.ForeignKey(
                        name: "FK_Opstina_Drzava_drzava_id",
                        column: x => x.drzava_id,
                        principalTable: "Drzava",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ispiti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PredmetID = table.Column<int>(type: "int", nullable: false),
                    DatumIspita = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ispiti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ispiti_Predmeti_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmeti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    broj_indeksa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opstina_rodjenja_id = table.Column<int>(type: "int", nullable: false),
                    datum_rodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    slika_studenta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id);
                    table.ForeignKey(
                        name: "FK_Student_Opstina_opstina_rodjenja_id",
                        column: x => x.opstina_rodjenja_id,
                        principalTable: "Opstina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocjene",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumOcjene = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    PredmetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjene", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ocjene_Predmeti_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmeti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocjene_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrijaveIspita",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPrijave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    IspitID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijaveIspita", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrijaveIspita_Ispiti_IspitID",
                        column: x => x.IspitID,
                        principalTable: "Ispiti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrijaveIspita_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ispiti_PredmetID",
                table: "Ispiti",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_PredmetID",
                table: "Ocjene",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_StudentID",
                table: "Ocjene",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Opstina_drzava_id",
                table: "Opstina",
                column: "drzava_id");

            migrationBuilder.CreateIndex(
                name: "IX_PrijaveIspita_IspitID",
                table: "PrijaveIspita",
                column: "IspitID");

            migrationBuilder.CreateIndex(
                name: "IX_PrijaveIspita_StudentID",
                table: "PrijaveIspita",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_opstina_rodjenja_id",
                table: "Student",
                column: "opstina_rodjenja_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ocjene");

            migrationBuilder.DropTable(
                name: "PrijaveIspita");

            migrationBuilder.DropTable(
                name: "Ispiti");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Predmeti");

            migrationBuilder.DropTable(
                name: "Opstina");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
