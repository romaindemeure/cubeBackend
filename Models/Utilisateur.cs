using System;
using System.Collections.Generic;

namespace cubeBackend.Models
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            CommandeClients = new HashSet<CommandeClient>();
            CommandeFournisseurs = new HashSet<CommandeFournisseur>();
            IdArticles = new HashSet<Article>();
        }

        public int IdClient { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set; }
        public string? MotDePasse { get; set; }
        public string? Adresse { get; set; }
        public string? CodePostal { get; set; }
        public string? Ville { get; set; }
        public string? Telephone { get; set; }
        public string? Administrateur { get; set; }

        public virtual ICollection<CommandeClient> CommandeClients { get; set; }
        public virtual ICollection<CommandeFournisseur> CommandeFournisseurs { get; set; }

        public virtual ICollection<Article> IdArticles { get; set; }
    }
}
