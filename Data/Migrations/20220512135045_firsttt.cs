using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class firsttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pays",
                columns: table => new
                {
                    CodePays = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Monnaie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.CodePays);
                });

            migrationBuilder.CreateTable(
                name: "Tournoi",
                columns: table => new
                {
                    NoTour = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Coef = table.Column<double>(type: "float", nullable: false),
                    Dotation = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournoi", x => x.NoTour);
                });

            migrationBuilder.CreateTable(
                name: "Joueur",
                columns: table => new
                {
                    JoueurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaysFK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueur", x => x.JoueurId);
                    table.ForeignKey(
                        name: "FK_Joueur_Pays_PaysFK",
                        column: x => x.PaysFK,
                        principalTable: "Pays",
                        principalColumn: "CodePays",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jouer",
                columns: table => new
                {
                    JoueurFK = table.Column<int>(type: "int", nullable: false),
                    TournoiFK = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jouer", x => new { x.JoueurFK, x.TournoiFK });
                    table.ForeignKey(
                        name: "FK_Jouer_Joueur_JoueurFK",
                        column: x => x.JoueurFK,
                        principalTable: "Joueur",
                        principalColumn: "JoueurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jouer_Tournoi_TournoiFK",
                        column: x => x.TournoiFK,
                        principalTable: "Tournoi",
                        principalColumn: "NoTour",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jouer_TournoiFK",
                table: "Jouer",
                column: "TournoiFK");

            migrationBuilder.CreateIndex(
                name: "IX_Joueur_PaysFK",
                table: "Joueur",
                column: "PaysFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jouer");

            migrationBuilder.DropTable(
                name: "Joueur");

            migrationBuilder.DropTable(
                name: "Tournoi");

            migrationBuilder.DropTable(
                name: "Pays");
        }
    }
}
