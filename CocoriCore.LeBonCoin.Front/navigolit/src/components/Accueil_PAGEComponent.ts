import { LitElement, html, property, customElement } from "lit-element"
import { InitPage } from './initPage';
@customElement('accueil-page')
class Accueil_PAGEComponent extends LitElement {
    //@property({ type: Array }) Categories: string[]
    render() { return html`accueil-page`; }


    Connexion: string;
    Inscription: string;
    Form: PageCall<Accueil_Page_Form_GET, Accueil_Page_Form_GETResponse>;
    Categories: Call<Categories_GET, Categories>;
}

class Accueil_Page_Form_GET {

}

class Accueil_Page_Form_GETResponse {
}
class Categories_GET { }

class Categories { }