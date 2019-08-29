
import { LitElement, html, property, customElement } from "lit-element";
import Navigo from "navigo/lib/navigo.es.js";

@customElement('my-app')
class MyApp extends LitElement {
  @property() route;

  constructor() {
    super()
    let router = new Navigo('/', false)
    
    router
    .on('/api', () => { this.route = html`<accueil-page></accueil-page>` })
    .on('/api/users/connexion', () => { this.route = html`<users-connexion-page></users-connexion-page>` })
    .on('/api/users/inscription', () => { this.route = html`<users-inscription-page></users-inscription-page>` })
    .on('/api/users/mot-de-passe-oublie', () => { this.route = html`<users-motdepasseoublie-page></users-motdepasseoublie-page>` })
    .on('/api/vendeur', () => { this.route = html`<vendeur-dashboard-page></vendeur-dashboard-page>` })
    .on('/api/vendeur/nouvelle-annonce', () => { this.route = html`<vendeur-nouvelleannonce-page></vendeur-nouvelleannonce-page>` })
    .on('/api/vendeur/annonces', () => { this.route = html`<vendeur-annonces-page></vendeur-annonces-page>` })
    .on('/api/vendeur/annonces/id:guid', () => { this.route = html`<vendeur-annonces-id-page></vendeur-annonces-id-page>` })
    .on('/api/annonces', () => { this.route = html`<annonces-page></annonces-page>` })
    .on('/api/annonces/id:guid', () => { this.route = html`<annonces-id-page></annonces-id-page>` })
    ;

    
    router.resolve()
  }
  render() {
    return html`
      <div>
        <h1>MyAwesomeApp</h1>
        ${this.route}
      </div>
    `
  }
}

