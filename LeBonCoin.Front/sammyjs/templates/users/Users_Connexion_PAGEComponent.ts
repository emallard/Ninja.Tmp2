class Users_Connexion_PAGEComponent extends Users_Connexion_PAGE {

    constructor() {
        super();
    }

    async postInit() {
        document.getElementById("motDePasseOublie").setAttribute("href", this.MotDePasseOublie);

        document.getElementById('form').addEventListener('submit', async (evt) => {
            evt.preventDefault();

            await this.submit(this.Form,
                {
                    Email: (<HTMLInputElement>document.getElementById("email")).value,
                    Password: (<HTMLInputElement>document.getElementById("password")).value,
                });

            return false;
        })
    }
}
