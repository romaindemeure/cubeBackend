using System;
using System.Collections.Generic;

namespace cubeBackend.Models
{
    public partial class Article
    {
        public Article()
        {
            IdClients = new HashSet<Utilisateur>();
        }

        public int IdArticle { get; set; }
        public string? Nom { get; set; }
        public string? Annee { get; set; }
        public string? PrixUnitaire { get; set; }
        public string? PrixCarton { get; set; }
        public string? PrixFournisseur { get; set; }
        public string? Reference { get; set; }
        public string? Tva { get; set; }
        public string? Domaine { get; set; }
        public string? Description { get; set; }
        public string? Famille { get; set; }
        public string? CoutStockage { get; set; }
        public int IdFournisseur { get; set; }
        public int IdCommandeClient { get; set; }

        public virtual CommandeClient IdCommandeClientNavigation { get; set; } = null!;
        public virtual Fournisseur IdFournisseurNavigation { get; set; } = null!;

        public virtual ICollection<Utilisateur> IdClients { get; set; }
    }
}
