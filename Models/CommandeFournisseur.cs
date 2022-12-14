using System;
using System.Collections.Generic;

namespace cubeBackend.Models
{
    public partial class CommandeFournisseur
    {
        public CommandeFournisseur()
        {
            Fournisseurs = new HashSet<Fournisseur>();
        }

        public int Id { get; set; }
        public int? NombreArticle { get; set; }
        public int? NumeroCommande { get; set; }
        public decimal? PrixHorsTaxe { get; set; }
        public decimal? PrixTtc { get; set; }
        public DateOnly? DateCommande { get; set; }
        public decimal? Reduction { get; set; }
        public decimal? CoutLivraison { get; set; }
        public int Id1 { get; set; }

        public virtual Utilisateur Id1Navigation { get; set; } = null!;
        public virtual ICollection<Fournisseur> Fournisseurs { get; set; }
    }
}
