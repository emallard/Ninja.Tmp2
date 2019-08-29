class Users_MotDePasseOublie_PAGEComponent extends Users_MotDePasseOublie_PAGE {

    constructor() {
        super();
    }

    async postInit() {
        document.getElementById('form').addEventListener('submit', async (evt) => {
            evt.preventDefault();
            /*
            await this.submit(this.Form,
                {
                    Email: (<HTMLInputElement>document.getElementById("email")).value
                });
            */
            return false;
        })
    }

}
