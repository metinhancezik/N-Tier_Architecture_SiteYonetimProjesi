using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    SiteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlokSayısı = table.Column<int>(type: "int", nullable: false),
                    DaireSayısı = table.Column<int>(type: "int", nullable: false),
                    IsitmaTipi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.SiteID);
                });

            migrationBuilder.CreateTable(
                name: "Bloks",
                columns: table => new
                {
                    BlokID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteID = table.Column<int>(type: "int", nullable: false),
                    BlokName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloks", x => x.BlokID);
                    table.ForeignKey(
                        name: "FK_Bloks_Sites_SiteID",
                        column: x => x.SiteID,
                        principalTable: "Sites",
                        principalColumn: "SiteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Giders",
                columns: table => new
                {
                    GiderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteID = table.Column<int>(type: "int", nullable: false),
                    HarcamaCinsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sirket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HarcananTutar = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giders", x => x.GiderID);
                    table.ForeignKey(
                        name: "FK_Giders_Sites_SiteID",
                        column: x => x.SiteID,
                        principalTable: "Sites",
                        principalColumn: "SiteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteYoneticisis",
                columns: table => new
                {
                    YoneticiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    SiteID = table.Column<int>(type: "int", nullable: false),
                    BlokName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteYoneticisis", x => x.YoneticiID);
                    table.ForeignKey(
                        name: "FK_SiteYoneticisis_Sites_SiteID",
                        column: x => x.SiteID,
                        principalTable: "Sites",
                        principalColumn: "SiteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Daires",
                columns: table => new
                {
                    DaireID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlokID = table.Column<int>(type: "int", nullable: false),
                    KatNumarasi = table.Column<int>(type: "int", nullable: false),
                    ExtraInformation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daires", x => x.DaireID);
                    table.ForeignKey(
                        name: "FK_Daires_Bloks_BlokID",
                        column: x => x.BlokID,
                        principalTable: "Bloks",
                        principalColumn: "BlokID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoneticiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_SiteYoneticisis_YoneticiID",
                        column: x => x.YoneticiID,
                        principalTable: "SiteYoneticisis",
                        principalColumn: "YoneticiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aidats",
                columns: table => new
                {
                    AidatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaireID = table.Column<int>(type: "int", nullable: false),
                    Tutar = table.Column<int>(type: "int", nullable: false),
                    Odenmis = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aidats", x => x.AidatID);
                    table.ForeignKey(
                        name: "FK_Aidats_Daires_DaireID",
                        column: x => x.DaireID,
                        principalTable: "Daires",
                        principalColumn: "DaireID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvSahibis",
                columns: table => new
                {
                    EvSahibiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaireID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvSahibis", x => x.EvSahibiID);
                    table.ForeignKey(
                        name: "FK_EvSahibis_Daires_DaireID",
                        column: x => x.DaireID,
                        principalTable: "Daires",
                        principalColumn: "DaireID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aidats_DaireID",
                table: "Aidats",
                column: "DaireID");

            migrationBuilder.CreateIndex(
                name: "IX_Bloks_SiteID",
                table: "Bloks",
                column: "SiteID");

            migrationBuilder.CreateIndex(
                name: "IX_Daires_BlokID",
                table: "Daires",
                column: "BlokID");

            migrationBuilder.CreateIndex(
                name: "IX_EvSahibis_DaireID",
                table: "EvSahibis",
                column: "DaireID");

            migrationBuilder.CreateIndex(
                name: "IX_Giders_SiteID",
                table: "Giders",
                column: "SiteID");

            migrationBuilder.CreateIndex(
                name: "IX_SiteYoneticisis_SiteID",
                table: "SiteYoneticisis",
                column: "SiteID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_YoneticiID",
                table: "Users",
                column: "YoneticiID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aidats");

            migrationBuilder.DropTable(
                name: "EvSahibis");

            migrationBuilder.DropTable(
                name: "Giders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Daires");

            migrationBuilder.DropTable(
                name: "SiteYoneticisis");

            migrationBuilder.DropTable(
                name: "Bloks");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
