using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class JoueurConfig : IEntityTypeConfiguration<Joueur>
    {
        public void Configure(EntityTypeBuilder<Joueur> builder)
        {
            builder.HasOne(joueur => joueur.Pays).WithMany(pays => pays.Joueurs)
                .HasForeignKey(joueur => joueur.PaysFK);

        }


    }
}