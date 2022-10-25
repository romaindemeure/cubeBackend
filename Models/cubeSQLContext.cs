using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cubeBackend.Models
{
    public partial class cubeSQLContext : DbContext
    {
        public cubeSQLContext()
        {
        }

        public cubeSQLContext(DbContextOptions<cubeSQLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<CommandeClient> CommandeClients { get; set; } = null!;
        public virtual DbSet<CommandeFournisseur> CommandeFournisseurs { get; set; } = null!;
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; } = null!;
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=cubeUser;password=rWjo0jpFuSpQwTQRM5n7Kg;database=cubeSQL", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");

                entity.HasIndex(e => e.Id1, "id_1");

                entity.HasIndex(e => e.Id2, "id_2");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Annee).HasColumnName("annee");

                entity.Property(e => e.CoutStockage)
                    .HasPrecision(15, 2)
                    .HasColumnName("coutStockage");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.Domaine)
                    .HasMaxLength(50)
                    .HasColumnName("domaine");

                entity.Property(e => e.Famille)
                    .HasMaxLength(50)
                    .HasColumnName("famille");

                entity.Property(e => e.Id1).HasColumnName("id_1");

                entity.Property(e => e.Id2).HasColumnName("id_2");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .HasColumnName("nom");

                entity.Property(e => e.PrixCarton)
                    .HasPrecision(15, 2)
                    .HasColumnName("prixCarton");

                entity.Property(e => e.PrixFournisseur)
                    .HasPrecision(15, 2)
                    .HasColumnName("prixFournisseur");

                entity.Property(e => e.PrixUnitaire)
                    .HasPrecision(15, 2)
                    .HasColumnName("prixUnitaire");

                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .HasColumnName("reference");

                entity.Property(e => e.Tva)
                    .HasPrecision(15, 2)
                    .HasColumnName("tva");

                entity.HasOne(d => d.Id1Navigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.Id1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("article_ibfk_1");

                entity.HasOne(d => d.Id2Navigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.Id2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("article_ibfk_2");

                entity.HasMany(d => d.Id1s)
                    .WithMany(p => p.Ids)
                    .UsingEntity<Dictionary<string, object>>(
                        "Gerer",
                        l => l.HasOne<Utilisateur>().WithMany().HasForeignKey("Id1").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("gerer_ibfk_2"),
                        r => r.HasOne<Article>().WithMany().HasForeignKey("Id").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("gerer_ibfk_1"),
                        j =>
                        {
                            j.HasKey("Id", "Id1").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("gerer");

                            j.HasIndex(new[] { "Id1" }, "id_1");

                            j.IndexerProperty<int>("Id").HasColumnName("id");

                            j.IndexerProperty<int>("Id1").HasColumnName("id_1");
                        });
            });

            modelBuilder.Entity<CommandeClient>(entity =>
            {
                entity.ToTable("commandeClient");

                entity.HasIndex(e => e.Id1, "id_1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CoutLivraison)
                    .HasPrecision(15, 2)
                    .HasColumnName("coutLivraison");

                entity.Property(e => e.DateCommande).HasColumnName("dateCommande");

                entity.Property(e => e.Id1).HasColumnName("id_1");

                entity.Property(e => e.NombreArticle).HasColumnName("nombreArticle");

                entity.Property(e => e.NumeroCommande).HasColumnName("numeroCommande");

                entity.Property(e => e.PrixHorsTaxe)
                    .HasPrecision(15, 2)
                    .HasColumnName("prixHorsTaxe");

                entity.Property(e => e.PrixTtc)
                    .HasPrecision(15, 2)
                    .HasColumnName("prixTTC");

                entity.Property(e => e.Reduction)
                    .HasPrecision(15, 2)
                    .HasColumnName("reduction");

                entity.HasOne(d => d.Id1Navigation)
                    .WithMany(p => p.CommandeClients)
                    .HasForeignKey(d => d.Id1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("commandeClient_ibfk_1");
            });

            modelBuilder.Entity<CommandeFournisseur>(entity =>
            {
                entity.ToTable("commandeFournisseur");

                entity.HasIndex(e => e.Id1, "id_1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CoutLivraison)
                    .HasPrecision(15, 2)
                    .HasColumnName("coutLivraison");

                entity.Property(e => e.DateCommande).HasColumnName("dateCommande");

                entity.Property(e => e.Id1).HasColumnName("id_1");

                entity.Property(e => e.NombreArticle).HasColumnName("nombreArticle");

                entity.Property(e => e.NumeroCommande).HasColumnName("numeroCommande");

                entity.Property(e => e.PrixHorsTaxe)
                    .HasPrecision(15, 2)
                    .HasColumnName("prixHorsTaxe");

                entity.Property(e => e.PrixTtc)
                    .HasPrecision(15, 2)
                    .HasColumnName("prixTTC");

                entity.Property(e => e.Reduction)
                    .HasPrecision(15, 2)
                    .HasColumnName("reduction");

                entity.HasOne(d => d.Id1Navigation)
                    .WithMany(p => p.CommandeFournisseurs)
                    .HasForeignKey(d => d.Id1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("commandeFournisseur_ibfk_1");
            });

            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.ToTable("fournisseur");

                entity.HasIndex(e => e.Id1, "id_1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(50)
                    .HasColumnName("adresse");

                entity.Property(e => e.CodePostal)
                    .HasMaxLength(50)
                    .HasColumnName("codePostal");

                entity.Property(e => e.CoordonneeBancaire)
                    .HasMaxLength(50)
                    .HasColumnName("coordonneeBancaire");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Id1).HasColumnName("id_1");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .HasColumnName("nom");

                entity.Property(e => e.Siret)
                    .HasMaxLength(50)
                    .HasColumnName("siret");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .HasColumnName("telephone");

                entity.Property(e => e.Ville)
                    .HasMaxLength(50)
                    .HasColumnName("ville");

                entity.HasOne(d => d.Id1Navigation)
                    .WithMany(p => p.Fournisseurs)
                    .HasForeignKey(d => d.Id1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fournisseur_ibfk_1");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.ToTable("utilisateur");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Administrateur).HasColumnName("administrateur");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(50)
                    .HasColumnName("adresse");

                entity.Property(e => e.CodePostal)
                    .HasMaxLength(50)
                    .HasColumnName("codePostal");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.MotDePasse)
                    .HasMaxLength(50)
                    .HasColumnName("motDePasse");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .HasColumnName("nom");

                entity.Property(e => e.Prenom)
                    .HasMaxLength(50)
                    .HasColumnName("prenom");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .HasColumnName("telephone");

                entity.Property(e => e.Ville)
                    .HasMaxLength(50)
                    .HasColumnName("ville");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
