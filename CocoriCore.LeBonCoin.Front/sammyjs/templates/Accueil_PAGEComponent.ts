class Accueil_PAGEComponent extends Accueil_PAGE {

    constructor() {
        super();
    }

    async postInit() {
        document.getElementById("Connexion").setAttribute("href", this.Connexion);
    }
}
