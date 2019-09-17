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
    Claims: IClaims;
    Redirect: string;
}

class IClaims {
}

class Users_Inscription_POST {
    Email: String;
    Password: String;
    PasswordConfirmation: String;
    Nom: String;
    Prenom: String;
}

class Users_Inscription_POSTResponse {
    Claims: IClaims;
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

