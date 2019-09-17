function addRoutes(app) {
app.addPage("", Accueil_PAGEComponent, "templates/Accueil_PAGEComponent.html");
app.addPage("/users/connexion", Users_Connexion_PAGEComponent, "templates/users/Users_Connexion_PAGEComponent.html");
app.addPage("/users/inscription", Users_Inscription_PAGEComponent, "templates/users/Users_Inscription_PAGEComponent.html");
app.addPage("/users/mot-de-passe-oublie", Users_MotDePasseOublie_PAGEComponent, "templates/users/Users_MotDePasseOublie_PAGEComponent.html");
app.addPage("/vendeur", Vendeur_Dashboard_PAGEComponent, "templates/vendeur/Vendeur_Dashboard_PAGEComponent.html");
app.addPage("/vendeur/nouvelle-annonce", Vendeur_NouvelleAnnonce_PAGEComponent, "templates/vendeur/Vendeur_NouvelleAnnonce_PAGEComponent.html");
app.addPage("/vendeur/annonces", Vendeur_Annonces_PAGEComponent, "templates/vendeur/Vendeur_Annonces_PAGEComponent.html");
app.addPage("/vendeur/annonces/id:guid", Vendeur_Annonces_Id_PAGEComponent, "templates/vendeur/Vendeur_Annonces_Id_PAGEComponent.html");
app.addPage("/annonces", Annonces_PAGEComponent, "templates/Annonces_PAGEComponent.html");
app.addPage("/annonces/id:guid", Annonces_Id_PAGEComponent, "templates/Annonces_Id_PAGEComponent.html");
}