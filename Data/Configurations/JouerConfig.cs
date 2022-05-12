using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class JouerConfig : IEntityTypeConfiguration<Jouer>
    {
        public void Configure(EntityTypeBuilder<Jouer> builder)
        {
            builder.HasKey(jouer => new { jouer.JoueurFK,jouer.TournoiFK });;
            builder.HasOne(jouer => jouer.Joueur).WithMany(joueur => joueur.Jouers).HasForeignKey(jouer => jouer.JoueurFK);
            builder.HasOne(jouer => jouer.Tournoi).WithMany(tournoi => tournoi.Jouers).HasForeignKey(jouer => jouer.TournoiFK);
        }
    }
}