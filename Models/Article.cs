using System;
using System.Collections.Generic;

namespace cubeBackend.Models
{
    public partial class Article
    {
        public Article()
        {
            Id1s = new HashSet<Utilisateur>();
        }

        public int Id { get; set; }
        public string? Nom { get; set; }
        public DateOnly? Annee { get; set; }
        public decimal? PrixUnitaire { get; set; }
        public decimal? PrixCarton { get; set; }
        public decimal? PrixFournisseur { get; set; }
        public string? Reference { get; set; }
        public decimal? Tva { get; set; }
        public string? Domaine { get; set; }
        public string? Description { get; set; }
        public string? Famille { get; set; }
        public decimal? CoutStockage { get; set; }
        public int Id1 { get; set; }
        public int Id2 { get; set; }

        public virtual Fournisseur Id1Navigation { get; set; } = null!;
        public virtual CommandeClient Id2Navigation { get; set; } = null!;

        public virtual ICollection<Utilisateur> Id1s { get; set; }
    }
}
