using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpukaAP01.Migrations
{
    public partial class TablaNueva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_AdressenTyp",
                columns: table => new
                {
                    adtTyp = table.Column<int>(nullable: false),
                    adtBezeichnung = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_AdressenTyp", x => x.adtTyp)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "t_Anrede",
                columns: table => new
                {
                    anrAnredeID = table.Column<int>(nullable: false),
                    anrAnrede = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    anrJNPerson = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Anrede", x => x.anrAnredeID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "t_BegStatus",
                columns: table => new
                {
                    bstStatus = table.Column<int>(nullable: false),
                    bstBezeichnung = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_BeguenstigtenStatus", x => x.bstStatus)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "t_EinrichtungTypen",
                columns: table => new
                {
                    eitTyp = table.Column<byte>(nullable: false),
                    eitBezeichnung = table.Column<string>(unicode: false, maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_EinrichtungTypen", x => x.eitTyp)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "t_Versorgungstypen",
                columns: table => new
                {
                    vetTyp = table.Column<byte>(nullable: false),
                    vetBezeichnung = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Versorgungstypen", x => x.vetTyp)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "t_ZusagenStatus",
                columns: table => new
                {
                    zstStatus = table.Column<byte>(nullable: false),
                    zstBezeichnung = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_ZusagenStatus", x => x.zstStatus)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "t_Adressen",
                columns: table => new
                {
                    adrAdresse = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    adrMandant = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    adrVorname = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    adrName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    adrTitel = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    adrStrasse = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    adrPLZ = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    adrOrt = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    adrAnrede = table.Column<int>(nullable: true),
                    adrGDatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    adrTyp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Adressen", x => x.adrAdresse)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Adressen_hat_die_Anrede",
                        column: x => x.adrAnrede,
                        principalTable: "t_Anrede",
                        principalColumn: "anrAnredeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adressen_hat_AdrTyp",
                        column: x => x.adrTyp,
                        principalTable: "t_AdressenTyp",
                        principalColumn: "adtTyp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_VereinbarungenDetails",
                columns: table => new
                {
                    vedID = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    vedLeistungsgruppe = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    vedVersorgungstyp = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_VereinbarungenDetails", x => x.vedID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_VereinbarungenDetails_hat_Typen",
                        column: x => x.vedVersorgungstyp,
                        principalTable: "t_Versorgungstypen",
                        principalColumn: "vetTyp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_Einrichtung",
                columns: table => new
                {
                    einID = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    einAdresse = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    einTyp = table.Column<byte>(nullable: true),
                    einBezeichnung = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Einrichtung", x => x.einID);
                    table.ForeignKey(
                        name: "FK_Einrichtung_hat_die_Adresse",
                        column: x => x.einAdresse,
                        principalTable: "t_Adressen",
                        principalColumn: "adrAdresse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Einrichtung_ist_vom_Typ",
                        column: x => x.einTyp,
                        principalTable: "t_EinrichtungTypen",
                        principalColumn: "eitTyp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_Mandanten",
                columns: table => new
                {
                    manMandant = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    manEinrichtung = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    manAdresse = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    manBezeichnung = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Mandanten", x => x.manMandant)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Mandanten_hat_Einrichtung",
                        column: x => x.manEinrichtung,
                        principalTable: "t_Einrichtung",
                        principalColumn: "einID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_Mitglieder",
                columns: table => new
                {
                    mitMitglied = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    mitMandant = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    mitAdresse = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Mitglieder", x => x.mitMitglied)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Mitglieder_hat_die_Adresse",
                        column: x => x.mitAdresse,
                        principalTable: "t_Adressen",
                        principalColumn: "adrAdresse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mitglieder_ist_vom_Mandant",
                        column: x => x.mitMandant,
                        principalTable: "t_Mandanten",
                        principalColumn: "manMandant",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_Beguenstigte",
                columns: table => new
                {
                    begBeguenstigter = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    begMitglied = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    begAdresse = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    begStatus = table.Column<int>(nullable: false),
                    begPersonalNr = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    begEintrittsdatum = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Beguenstigte", x => x.begBeguenstigter);
                    table.ForeignKey(
                        name: "FK_Begungstigte_hat_die_Adresse",
                        column: x => x.begAdresse,
                        principalTable: "t_Adressen",
                        principalColumn: "adrAdresse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Begungstigte_hat_Mitglieder",
                        column: x => x.begMitglied,
                        principalTable: "t_Mitglieder",
                        principalColumn: "mitMitglied",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Begungstigte_hat_Status",
                        column: x => x.begStatus,
                        principalTable: "t_BegStatus",
                        principalColumn: "bstStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_Vereinbarungen",
                columns: table => new
                {
                    verVereinbarung = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    verMitglied = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    verGueltigAb = table.Column<DateTime>(type: "datetime", nullable: false),
                    verGueltigBis = table.Column<DateTime>(type: "datetime", nullable: true),
                    verBezeichnung = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Vereinbarungen", x => x.verVereinbarung)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Vereinbarungen_hat_Mitglied",
                        column: x => x.verMitglied,
                        principalTable: "t_Mitglieder",
                        principalColumn: "mitMitglied",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_VereinbarLeistgruppen",
                columns: table => new
                {
                    vlgLeistungsgruppe = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    vlgVereinbarung = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    vlgBezeichnung = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    vlgAV = table.Column<bool>(nullable: false),
                    vlgWuWRente = table.Column<bool>(nullable: false),
                    vlgTodesfall = table.Column<bool>(nullable: false),
                    vlgInvaliditaet = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_VereinbarungenLeistungsgruppen", x => x.vlgLeistungsgruppe)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_VereinbarLeistgruppen_hat_Vereinbarung",
                        column: x => x.vlgVereinbarung,
                        principalTable: "t_Vereinbarungen",
                        principalColumn: "verVereinbarung",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_Zusagen",
                columns: table => new
                {
                    zusZusage = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    zusBeguenstigter = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    zusLeistungsgruppe = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    zusGueltigAb = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Zusagen", x => x.zusZusage)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Zusagen_hat_Beguenstigte",
                        column: x => x.zusBeguenstigter,
                        principalTable: "t_Beguenstigte",
                        principalColumn: "begBeguenstigter",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zusagen_hat_VerLeistunGrup",
                        column: x => x.zusLeistungsgruppe,
                        principalTable: "t_VereinbarLeistgruppen",
                        principalColumn: "vlgLeistungsgruppe",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_ZusagenDetails",
                columns: table => new
                {
                    zudID = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    zudZusage = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    zudVersorgungstyp = table.Column<byte>(nullable: false),
                    zudGueltigAb = table.Column<DateTime>(type: "datetime", nullable: false),
                    zudStatus = table.Column<byte>(nullable: false),
                    zudWertEin = table.Column<decimal>(type: "money", nullable: false),
                    zudWertAus = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_ZusagenDetails", x => x.zudID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ZusagenDetails_hat_Status",
                        column: x => x.zudStatus,
                        principalTable: "t_ZusagenStatus",
                        principalColumn: "zstStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZusagenDetails_zum_versorgTyp",
                        column: x => x.zudVersorgungstyp,
                        principalTable: "t_Versorgungstypen",
                        principalColumn: "vetTyp",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZusagenDetails_kpmm_von_Zug",
                        column: x => x.zudZusage,
                        principalTable: "t_Zusagen",
                        principalColumn: "zusZusage",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_Adressen_adrAnrede",
                table: "t_Adressen",
                column: "adrAnrede");

            migrationBuilder.CreateIndex(
                name: "IX_t_Adressen_adrTyp",
                table: "t_Adressen",
                column: "adrTyp");

            migrationBuilder.CreateIndex(
                name: "IX_t_Beguenstigte_begAdresse",
                table: "t_Beguenstigte",
                column: "begAdresse");

            migrationBuilder.CreateIndex(
                name: "IX_t_Beguenstigte_begMitglied",
                table: "t_Beguenstigte",
                column: "begMitglied");

            migrationBuilder.CreateIndex(
                name: "IX_t_Beguenstigte_begStatus",
                table: "t_Beguenstigte",
                column: "begStatus");

            migrationBuilder.CreateIndex(
                name: "IX_t_Einrichtung_einAdresse",
                table: "t_Einrichtung",
                column: "einAdresse");

            migrationBuilder.CreateIndex(
                name: "IX_t_Einrichtung_einTyp",
                table: "t_Einrichtung",
                column: "einTyp");

            migrationBuilder.CreateIndex(
                name: "IX_t_Mandanten_manEinrichtung",
                table: "t_Mandanten",
                column: "manEinrichtung");

            migrationBuilder.CreateIndex(
                name: "IX_t_Mitglieder_mitAdresse",
                table: "t_Mitglieder",
                column: "mitAdresse");

            migrationBuilder.CreateIndex(
                name: "IX_t_Mitglieder_mitMandant",
                table: "t_Mitglieder",
                column: "mitMandant");

            migrationBuilder.CreateIndex(
                name: "IX_t_VereinbarLeistgruppen_vlgVereinbarung",
                table: "t_VereinbarLeistgruppen",
                column: "vlgVereinbarung");

            migrationBuilder.CreateIndex(
                name: "IX_t_Vereinbarungen_verMitglied",
                table: "t_Vereinbarungen",
                column: "verMitglied");

            migrationBuilder.CreateIndex(
                name: "IX_t_VereinbarungenDetails_vedVersorgungstyp",
                table: "t_VereinbarungenDetails",
                column: "vedVersorgungstyp");

            migrationBuilder.CreateIndex(
                name: "IX_t_Zusagen_zusBeguenstigter",
                table: "t_Zusagen",
                column: "zusBeguenstigter");

            migrationBuilder.CreateIndex(
                name: "IX_t_Zusagen_zusLeistungsgruppe",
                table: "t_Zusagen",
                column: "zusLeistungsgruppe");

            migrationBuilder.CreateIndex(
                name: "IX_t_ZusagenDetails_zudStatus",
                table: "t_ZusagenDetails",
                column: "zudStatus");

            migrationBuilder.CreateIndex(
                name: "IX_t_ZusagenDetails_zudVersorgungstyp",
                table: "t_ZusagenDetails",
                column: "zudVersorgungstyp");

            migrationBuilder.CreateIndex(
                name: "IX_t_ZusagenDetails_zudZusage",
                table: "t_ZusagenDetails",
                column: "zudZusage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_VereinbarungenDetails");

            migrationBuilder.DropTable(
                name: "t_ZusagenDetails");

            migrationBuilder.DropTable(
                name: "t_ZusagenStatus");

            migrationBuilder.DropTable(
                name: "t_Versorgungstypen");

            migrationBuilder.DropTable(
                name: "t_Zusagen");

            migrationBuilder.DropTable(
                name: "t_Beguenstigte");

            migrationBuilder.DropTable(
                name: "t_VereinbarLeistgruppen");

            migrationBuilder.DropTable(
                name: "t_BegStatus");

            migrationBuilder.DropTable(
                name: "t_Vereinbarungen");

            migrationBuilder.DropTable(
                name: "t_Mitglieder");

            migrationBuilder.DropTable(
                name: "t_Mandanten");

            migrationBuilder.DropTable(
                name: "t_Einrichtung");

            migrationBuilder.DropTable(
                name: "t_Adressen");

            migrationBuilder.DropTable(
                name: "t_EinrichtungTypen");

            migrationBuilder.DropTable(
                name: "t_Anrede");

            migrationBuilder.DropTable(
                name: "t_AdressenTyp");
        }
    }
}
