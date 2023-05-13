using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Odev1_KutuphaneEf.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Islemler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    KitapId = table.Column<int>(type: "int", nullable: false),
                    OduncAldigiTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IadeEdildiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islemler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SayfaSayisi = table.Column<int>(type: "int", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YazarId = table.Column<int>(type: "int", nullable: false),
                    BasimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YayınEviId = table.Column<int>(type: "int", nullable: false),
                    TurId = table.Column<int>(type: "int", nullable: false),
                    Dil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KitapSayisi = table.Column<int>(type: "int", nullable: false),
                    Cevirmen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Sinif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AktifMi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YayinEvleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YayinEviAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayinEvleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazarAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IslemKitap",
                columns: table => new
                {
                    IslemlerId = table.Column<int>(type: "int", nullable: false),
                    KitaplarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IslemKitap", x => new { x.IslemlerId, x.KitaplarId });
                    table.ForeignKey(
                        name: "FK_IslemKitap_Islemler_IslemlerId",
                        column: x => x.IslemlerId,
                        principalTable: "Islemler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IslemKitap_Kitaplar_KitaplarId",
                        column: x => x.KitaplarId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IslemOgrenci",
                columns: table => new
                {
                    IslemlerId = table.Column<int>(type: "int", nullable: false),
                    OgrencilerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IslemOgrenci", x => new { x.IslemlerId, x.OgrencilerId });
                    table.ForeignKey(
                        name: "FK_IslemOgrenci_Islemler_IslemlerId",
                        column: x => x.IslemlerId,
                        principalTable: "Islemler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IslemOgrenci_Ogrenciler_OgrencilerId",
                        column: x => x.OgrencilerId,
                        principalTable: "Ogrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitapTur",
                columns: table => new
                {
                    KitaplarId = table.Column<int>(type: "int", nullable: false),
                    TurlerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapTur", x => new { x.KitaplarId, x.TurlerId });
                    table.ForeignKey(
                        name: "FK_KitapTur_Kitaplar_KitaplarId",
                        column: x => x.KitaplarId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapTur_Turler_TurlerId",
                        column: x => x.TurlerId,
                        principalTable: "Turler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitapYayinEvi",
                columns: table => new
                {
                    KitaplarId = table.Column<int>(type: "int", nullable: false),
                    YayinEvleriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapYayinEvi", x => new { x.KitaplarId, x.YayinEvleriId });
                    table.ForeignKey(
                        name: "FK_KitapYayinEvi_Kitaplar_KitaplarId",
                        column: x => x.KitaplarId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapYayinEvi_YayinEvleri_YayinEvleriId",
                        column: x => x.YayinEvleriId,
                        principalTable: "YayinEvleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitapYazar",
                columns: table => new
                {
                    KitaplarId = table.Column<int>(type: "int", nullable: false),
                    YazarlarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapYazar", x => new { x.KitaplarId, x.YazarlarId });
                    table.ForeignKey(
                        name: "FK_KitapYazar_Kitaplar_KitaplarId",
                        column: x => x.KitaplarId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapYazar_Yazarlar_YazarlarId",
                        column: x => x.YazarlarId,
                        principalTable: "Yazarlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IslemKitap_KitaplarId",
                table: "IslemKitap",
                column: "KitaplarId");

            migrationBuilder.CreateIndex(
                name: "IX_IslemOgrenci_OgrencilerId",
                table: "IslemOgrenci",
                column: "OgrencilerId");

            migrationBuilder.CreateIndex(
                name: "IX_KitapTur_TurlerId",
                table: "KitapTur",
                column: "TurlerId");

            migrationBuilder.CreateIndex(
                name: "IX_KitapYayinEvi_YayinEvleriId",
                table: "KitapYayinEvi",
                column: "YayinEvleriId");

            migrationBuilder.CreateIndex(
                name: "IX_KitapYazar_YazarlarId",
                table: "KitapYazar",
                column: "YazarlarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IslemKitap");

            migrationBuilder.DropTable(
                name: "IslemOgrenci");

            migrationBuilder.DropTable(
                name: "KitapTur");

            migrationBuilder.DropTable(
                name: "KitapYayinEvi");

            migrationBuilder.DropTable(
                name: "KitapYazar");

            migrationBuilder.DropTable(
                name: "Islemler");

            migrationBuilder.DropTable(
                name: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "Turler");

            migrationBuilder.DropTable(
                name: "YayinEvleri");

            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "Yazarlar");
        }
    }
}
