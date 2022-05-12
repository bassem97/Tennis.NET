﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Jouer", b =>
                {
                    b.Property<int>("JoueurFK")
                        .HasColumnType("int");

                    b.Property<int>("TournoiFK")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("JoueurFK", "TournoiFK");

                    b.HasIndex("TournoiFK");

                    b.ToTable("Jouer");
                });

            modelBuilder.Entity("Domain.Joueur", b =>
                {
                    b.Property<int>("JoueurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaysFK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JoueurId");

                    b.HasIndex("PaysFK");

                    b.ToTable("Joueur");
                });

            modelBuilder.Entity("Domain.Pays", b =>
                {
                    b.Property<string>("CodePays")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Monnaie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodePays");

                    b.ToTable("Pays");
                });

            modelBuilder.Entity("Domain.Tournoi", b =>
                {
                    b.Property<int>("NoTour")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Coef")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Dotation")
                        .HasColumnType("float");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoTour");

                    b.ToTable("Tournoi");
                });

            modelBuilder.Entity("Domain.Jouer", b =>
                {
                    b.HasOne("Domain.Joueur", "Joueur")
                        .WithMany("Jouers")
                        .HasForeignKey("JoueurFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Tournoi", "Tournoi")
                        .WithMany("Jouers")
                        .HasForeignKey("TournoiFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Joueur");

                    b.Navigation("Tournoi");
                });

            modelBuilder.Entity("Domain.Joueur", b =>
                {
                    b.HasOne("Domain.Pays", "Pays")
                        .WithMany("Joueurs")
                        .HasForeignKey("PaysFK");

                    b.Navigation("Pays");
                });

            modelBuilder.Entity("Domain.Joueur", b =>
                {
                    b.Navigation("Jouers");
                });

            modelBuilder.Entity("Domain.Pays", b =>
                {
                    b.Navigation("Joueurs");
                });

            modelBuilder.Entity("Domain.Tournoi", b =>
                {
                    b.Navigation("Jouers");
                });
#pragma warning restore 612, 618
        }
    }
}
