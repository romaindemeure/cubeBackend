using System;
using System.Collections.Generic;

namespace cubeBackend.Models
{
    public partial class CommandeClient
    {
        public CommandeClient()
        {
            Articles = new HashSet<Article>();
        }

        public int IdCommandeClient { get; set; }
        public string? NombreArticle { get; set; }
        public string? NumeroCommande { get; set; }
        public string? PrixHorsTaxe { get; set; }
        public string? PrixTtc { get; set; }
        public string? DateCommande { get; set; }
        public string? Reduction { get; set; }
        public string? CoutLivraison { get; set; }
        public int IdClient { get; set; }

        public virtual Utilisateur IdClientNavigation { get; set; } = null!;
        public virtual ICollection<Article> Articles { get; set; }
    }
}
