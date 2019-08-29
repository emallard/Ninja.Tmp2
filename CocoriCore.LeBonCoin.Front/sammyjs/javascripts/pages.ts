class Annonces_POST {
    Ville: String;
    Categorie: String;
}

class Annonces_POSTResponse {
    Redirect: string;
}

class Villes_GET {
    Texte: String;
}

class Villes_GETResponse {
    Resultats: String[];
}

class Users_Connexion_POST {
    Email: String;
    Password: String;
}

class Users_Connexion_POSTResponse {
    Token: String;
    Redirect: string;
}

class Users_Inscription_POST {
    Email: String;
    Password: String;
    PasswordConfirmation: String;
    Nom: String;
    Prenom: String;
    DateNaissance: String;
}

class Users_Inscription_POSTResponse {
    jwt: String;
    Redirect: string;
}

class Users_MotDePasseOublie_POST {
    Email: String;
}

class Users_MotDePasseOublie_POSTResponse {
    Redirect: string;
}

class MenuUtilisateur {
    Deconnexion: string;
    Connexion: string;
    Inscription: string;
}

class Vendeur_NouvelleAnnonce_POST {
    Ville: String;
    Categorie: String;
}

class Vendeur_NouvelleAnnonce_POSTResponse {
    Redirect: string;
}

class Vendeur_Annonces_PAGEResponseItem {
    Id: Guid;
    Lien: string;
}

class Guid {
}

class Vendeur_Annonces_Id_Cancel_POST {
    Id: Guid;
}

class Annonces_PAGEItem {
    Id: Guid;
    Ville: String;
    Categorie: String;
    Text: String;
    Lien: string;
}

abstract class Accueil_PAGE extends Page {
    PageUrl:string = '/api';
    Categories: String[];
    Connexion: string;
    Inscription: string;
    Form: Form<Annonces_POST, Annonces_POSTResponse>;
    RechercheVille: Form<Villes_GET, Villes_GETResponse>;
}

abstract class Users_Connexion_PAGE extends Page {
    PageUrl:string = '/api/users/connexion';
    MotDePasseOublie: string;
    Form: Form<Users_Connexion_POST, Users_Connexion_POSTResponse>;
}

abstract class Users_Inscription_PAGE extends Page {
    PageUrl:string = '/api/users/inscription';
    Form: Form<Users_Inscription_POST, Users_Inscription_POSTResponse>;
}

abstract class Users_MotDePasseOublie_PAGE extends Page {
    PageUrl:string = '/api/users/mot-de-passe-oublie';
    Form: Form<Users_MotDePasseOublie_POST, Users_MotDePasseOublie_POSTResponse>;
}

abstract class Vendeur_Dashboard_PAGE extends Page {
    PageUrl:string = '/api/vendeur';
    Nom: String;
    Prenom: String;
    MenuUtilisateur: MenuUtilisateur;
    NouvelleAnnonce: string;
    Reunions: string;
}

abstract class Vendeur_NouvelleAnnonce_PAGE extends Page {
    PageUrl:string = '/api/vendeur/nouvelle-annonce';
    Categories: String[];
    Form: Form<Vendeur_NouvelleAnnonce_POST, Vendeur_NouvelleAnnonce_POSTResponse>;
}

abstract class Vendeur_Annonces_PAGE extends Page {
    PageUrl:string = '/api/vendeur/annonces';
    Annonces: Vendeur_Annonces_PAGEResponseItem[];
    NouvelleReunion: string;
}

abstract class Vendeur_Annonces_Id_PAGE extends Page {
    PageUrl:string = '/api/vendeur/annonces/id:guid';
    Id: Guid;
    Ville: String;
    Categorie: String;
    Cancel: Vendeur_Annonces_Id_Cancel_POST;
    Edit: string;
}

abstract class Annonces_PAGE extends Page {
    PageUrl:string = '/api/annonces';
    Items: Annonces_PAGEItem[];
    Form: Form<Annonces_POST, Annonces_POSTResponse>;
}

abstract class Annonces_Id_PAGE extends Page {
    PageUrl:string = '/api/annonces/id:guid';
    Ville: String;
    Categorie: String;
    Text: String;
}

