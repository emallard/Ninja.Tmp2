import { LitElement, html, property, customElement } from "lit-element"
import { InitPage } from './initPage';
@customElement('vendeur-dashboard-page')
class Vendeur_Dashboard_PAGEComponent extends LitElement{
@property({type : String}) Nom: string
@property({type : String}) Prenom: string
@property({type : Object}) MenuUtilisateur: t.Name
render() { return html`vendeur-dashboard-page`; }}
