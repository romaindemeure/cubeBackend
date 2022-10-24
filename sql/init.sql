CREATE TABLE utilisateur(
   Id_client INT,
   nom VARCHAR(50),
   prenom VARCHAR(50),
   email VARCHAR(50),
   motDePasse VARCHAR(50),
   adresse VARCHAR(50),
   codePostal VARCHAR(50),
   ville VARCHAR(50),
   telephone VARCHAR(50),
   administrateur VARCHAR(50),
   PRIMARY KEY(Id_client)
);

CREATE TABLE commandeClient(
   Id_commandeClient INT,
   nombreArticle VARCHAR(50),
   numeroCommande VARCHAR(50),
   prixHorsTaxe VARCHAR(50),
   prixTTC VARCHAR(50),
   dateCommande VARCHAR(50),
   reduction VARCHAR(50),
   coutLivraison VARCHAR(50),
   Id_client INT NOT NULL,
   PRIMARY KEY(Id_commandeClient),
   FOREIGN KEY(Id_client) REFERENCES utilisateur(Id_client)
);

CREATE TABLE commandeFournisseur(
   Id_commandeFournisseur INT,
   nombreArticle VARCHAR(50),
   numeroCommande VARCHAR(50),
   prixHorsTaxe VARCHAR(50),
   prixTTC VARCHAR(50),
   dateCommande VARCHAR(50),
   reduction VARCHAR(50),
   coutLivraison VARCHAR(50),
   Id_client INT NOT NULL,
   PRIMARY KEY(Id_commandeFournisseur),
   FOREIGN KEY(Id_client) REFERENCES utilisateur(Id_client)
);

CREATE TABLE fournisseur(
   Id_fournisseur INT,
   nom VARCHAR(50),
   email VARCHAR(50),
   telephone VARCHAR(50),
   siret VARCHAR(50),
   coordonneeBancaire VARCHAR(50),
   adresse VARCHAR(50),
   codePostal VARCHAR(50),
   ville VARCHAR(50),
   description VARCHAR(50),
   Id_commandeFournisseur INT NOT NULL,
   PRIMARY KEY(Id_fournisseur),
   FOREIGN KEY(Id_commandeFournisseur) REFERENCES commandeFournisseur(Id_commandeFournisseur)
);

CREATE TABLE article(
   Id_article INT,
   nom VARCHAR(50),
   annee VARCHAR(50),
   prixUnitaire VARCHAR(50),
   prixCarton VARCHAR(50),
   prixFournisseur VARCHAR(50),
   reference VARCHAR(50),
   tva VARCHAR(50),
   domaine VARCHAR(50),
   description VARCHAR(50),
   famille VARCHAR(50),
   coutStockage VARCHAR(50),
   Id_fournisseur INT NOT NULL,
   Id_commandeClient INT NOT NULL,
   PRIMARY KEY(Id_article),
   FOREIGN KEY(Id_fournisseur) REFERENCES fournisseur(Id_fournisseur),
   FOREIGN KEY(Id_commandeClient) REFERENCES commandeClient(Id_commandeClient)
);

CREATE TABLE gerer(
   Id_article INT,
   Id_client INT,
   PRIMARY KEY(Id_article, Id_client),
   FOREIGN KEY(Id_article) REFERENCES article(Id_article),
   FOREIGN KEY(Id_client) REFERENCES utilisateur(Id_client)
);
