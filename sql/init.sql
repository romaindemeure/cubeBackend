CREATE TABLE utilisateur(
   id INT,
   nom VARCHAR(50),
   prenom VARCHAR(50),
   email VARCHAR(50),
   motDePasse VARCHAR(50),
   adresse VARCHAR(50),
   codePostal VARCHAR(50),
   ville VARCHAR(50),
   telephone VARCHAR(50),
   administrateur TINYINT(1),
   PRIMARY KEY(id)
);

CREATE TABLE commandeClient(
   id INT,
   nombreArticle INT,
   numeroCommande INT,
   prixHorsTaxe DECIMAL(15,2),
   prixTTC DECIMAL(15,2),
   dateCommande DATE,
   reduction DECIMAL(15,2),
   coutLivraison DECIMAL(15,2),
   id_1 INT NOT NULL,
   PRIMARY KEY(id),
   FOREIGN KEY(id_1) REFERENCES utilisateur(id)
);

CREATE TABLE commandeFournisseur(
   id INT,
   nombreArticle INT,
   numeroCommande INT,
   prixHorsTaxe DECIMAL(15,2),
   prixTTC DECIMAL(15,2),
   dateCommande DATE,
   reduction DECIMAL(15,2),
   coutLivraison DECIMAL(15,2),
   id_1 INT NOT NULL,
   PRIMARY KEY(id),
   FOREIGN KEY(id_1) REFERENCES utilisateur(id)
);

CREATE TABLE fournisseur(
   id INT,
   nom VARCHAR(50),
   email VARCHAR(50),
   telephone VARCHAR(50),
   siret VARCHAR(50),
   coordonneeBancaire VARCHAR(50),
   adresse VARCHAR(50),
   codePostal VARCHAR(50),
   ville VARCHAR(50),
   description VARCHAR(50),
   id_1 INT NOT NULL,
   PRIMARY KEY(id),
   FOREIGN KEY(id_1) REFERENCES commandeFournisseur(id)
);

CREATE TABLE article(
   id INT,
   nom VARCHAR(50),
   annee DATE,
   prixUnitaire DECIMAL(15,2),
   prixCarton DECIMAL(15,2),
   prixFournisseur DECIMAL(15,2),
   reference VARCHAR(50),
   tva DECIMAL(15,2),
   domaine VARCHAR(50),
   description VARCHAR(50),
   famille VARCHAR(50),
   coutStockage DECIMAL(15,2),
   id_1 INT NOT NULL,
   id_2 INT NOT NULL,
   PRIMARY KEY(id),
   FOREIGN KEY(id_1) REFERENCES fournisseur(id),
   FOREIGN KEY(id_2) REFERENCES commandeClient(id)
);

CREATE TABLE gerer(
   id INT,
   id_1 INT,
   PRIMARY KEY(id, id_1),
   FOREIGN KEY(id) REFERENCES article(id),
   FOREIGN KEY(id_1) REFERENCES utilisateur(id)
);
