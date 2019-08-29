## Creation de code métier réutilisable :

MessageBus : Recopier les fichiers du répertoire message => Donne une base pour travailler avec des handlers (Pas de dépendance Cocoricore)
Possibilité de rajouter des IQuery, des ICommand, etc...

Api : contient les messages et les handlers : possibilité de mettre des Links et des Submits

Test : contient un TestBase pour l'Injection et pour pouvoir récupérer un TestUser qui est le point de base pour parcourir l'Api

## Creation du serveur :

= rajout d'un routeur vers message et de la serialization de la réponse

## POC

Page d'accueil vers 2 pages inscription/connexion
connexion = 1 formulaire simple vers une page dont l'url est sans parametre
creation d'une annonce => 1 formulaire avec une redirection vers une page qui contient un ID.

Peut-on faire un CocoriCore.Messages, qui contiendrait les messages les plus courant avec serialization / deserialization ?
Mais il faut aussi un CocoriCore.Repository