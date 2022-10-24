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
                entity.HasKey(e => e.IdArticle)
                    .HasName("PRIMARY");

                entity.ToTable("article");

                entity.HasIndex(e => e.IdCommandeClient, "Id_commandeClient");

                entity.HasIndex(e => e.IdFournisseur, "Id_fournisseur");

                entity.Property(e => e.IdArticle)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_article");

                entity.Property(e => e.Annee)
                    .HasMaxLength(50)
                    .HasColumnName("annee");

                entity.Property(e => e.CoutStockage)
                    .HasMaxLength(50)
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

                entity.Property(e => e.IdCommandeClient).HasColumnName("Id_commandeClient");

                entity.Property(e => e.IdFournisseur).HasColumnName("Id_fournisseur");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .HasColumnName("nom");

                entity.Property(e => e.PrixCarton)
                    .HasMaxLength(50)
                    .HasColumnName("prixCarton");

                entity.Property(e => e.PrixFournisseur)
                    .HasMaxLength(50)
                    .HasColumnName("prixFournisseur");

                entity.Property(e => e.PrixUnitaire)
                    .HasMaxLength(50)
                    .HasColumnName("prixUnitaire");

                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .HasColumnName("reference");

                entity.Property(e => e.Tva)
                    .HasMaxLength(50)
                    .HasColumnName("tva");

                entity.HasOne(d => d.IdCommandeClientNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdCommandeClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("article_ibfk_2");

                entity.HasOne(d => d.IdFournisseurNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdFournisseur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("article_ibfk_1");

                entity.HasMany(d => d.IdClients)
                    .WithMany(p => p.IdArticles)
                    .UsingEntity<Dictionary<string, object>>(
                        "Gerer",
                        l => l.HasOne<Utilisateur>().WithMany().HasForeignKey("IdClient").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("gerer_ibfk_2"),
                        r => r.HasOne<Article>().WithMany().HasForeignKey("IdArticle").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("gerer_ibfk_1"),
                        j =>
                        {
                            j.HasKey("IdArticle", "IdClient").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("gerer");

                            j.HasIndex(new[] { "IdClient" }, "Id_client");

                            j.IndexerProperty<int>("IdArticle").HasColumnName("Id_article");

                            j.IndexerProperty<int>("IdClient").HasColumnName("Id_client");
                        });
            });

            modelBuilder.Entity<CommandeClient>(entity =>
            {
                entity.HasKey(e => e.IdCommandeClient)
                    .HasName("PRIMARY");

                entity.ToTable("commandeClient");

                entity.HasIndex(e => e.IdClient, "Id_client");

                entity.Property(e => e.IdCommandeClient)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_commandeClient");

                entity.Property(e => e.CoutLivraison)
                    .HasMaxLength(50)
                    .HasColumnName("coutLivraison");

                entity.Property(e => e.DateCommande)
                    .HasMaxLength(50)
                    .HasColumnName("dateCommande");

                entity.Property(e => e.IdClient).HasColumnName("Id_client");

                entity.Property(e => e.NombreArticle)
                    .HasMaxLength(50)
                    .HasColumnName("nombreArticle");

                entity.Property(e => e.NumeroCommande)
                    .HasMaxLength(50)
                    .HasColumnName("numeroCommande");

                entity.Property(e => e.PrixHorsTaxe)
                    .HasMaxLength(50)
                    .HasColumnName("prixHorsTaxe");

                entity.Property(e => e.PrixTtc)
                    .HasMaxLength(50)
                    .HasColumnName("prixTTC");

                entity.Property(e => e.Reduction)
                    .HasMaxLength(50)
                    .HasColumnName("reduction");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.CommandeClients)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("commandeClient_ibfk_1");
            });

            modelBuilder.Entity<CommandeFournisseur>(entity =>
            {
                entity.HasKey(e => e.IdCommandeFournisseur)
                    .HasName("PRIMARY");

                entity.ToTable("commandeFournisseur");

                entity.HasIndex(e => e.IdClient, "Id_client");

                entity.Property(e => e.IdCommandeFournisseur)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_commandeFournisseur");

                entity.Property(e => e.CoutLivraison)
                    .HasMaxLength(50)
                    .HasColumnName("coutLivraison");

                entity.Property(e => e.DateCommande)
                    .HasMaxLength(50)
                    .HasColumnName("dateCommande");

                entity.Property(e => e.IdClient).HasColumnName("Id_client");

                entity.Property(e => e.NombreArticle)
                    .HasMaxLength(50)
                    .HasColumnName("nombreArticle");

                entity.Property(e => e.NumeroCommande)
                    .HasMaxLength(50)
                    .HasColumnName("numeroCommande");

                entity.Property(e => e.PrixHorsTaxe)
                    .HasMaxLength(50)
                    .HasColumnName("prixHorsTaxe");

                entity.Property(e => e.PrixTtc)
                    .HasMaxLength(50)
                    .HasColumnName("prixTTC");

                entity.Property(e => e.Reduction)
                    .HasMaxLength(50)
                    .HasColumnName("reduction");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.CommandeFournisseurs)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("commandeFournisseur_ibfk_1");
            });

            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.HasKey(e => e.IdFournisseur)
                    .HasName("PRIMARY");

                entity.ToTable("fournisseur");

                entity.HasIndex(e => e.IdCommandeFournisseur, "Id_commandeFournisseur");

                entity.Property(e => e.IdFournisseur)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_fournisseur");

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

                entity.Property(e => e.IdCommandeFournisseur).HasColumnName("Id_commandeFournisseur");

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

                entity.HasOne(d => d.IdCommandeFournisseurNavigation)
                    .WithMany(p => p.Fournisseurs)
                    .HasForeignKey(d => d.IdCommandeFournisseur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fournisseur_ibfk_1");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PRIMARY");

                entity.ToTable("utilisateur");

                entity.Property(e => e.IdClient)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_client");

                entity.Property(e => e.Administrateur)
                    .HasMaxLength(50)
                    .HasColumnName("administrateur");

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
