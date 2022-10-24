using System;
using System.Collections.Generic;

namespace cubeBackend.Models
{
    public partial class Fournisseur
    {
        public Fournisseur()
        {
            Articles = new HashSet<Article>();
        }

        public int IdFournisseur { get; set; }
        public string? Nom { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Siret { get; set; }
        public string? CoordonneeBancaire { get; set; }
        public string? Adresse { get; set; }
        public string? CodePostal { get; set; }
        public string? Ville { get; set; }
        public string? Description { get; set; }
        public int IdCommandeFournisseur { get; set; }

        public virtual CommandeFournisseur IdCommandeFournisseurNavigation { get; set; } = null!;
        public virtual ICollection<Article> Articles { get; set; }
    }
}
