import { LitElement, html, property, customElement } from "lit-element"
import { InitPage } from './initPage';
@customElement('vendeur-annonces-id-page')
class Vendeur_Annonces_Id_PAGEComponent extends LitElement{
@property({type : Object}) Id: t.Name
@property({type : String}) Ville: string
@property({type : String}) Categorie: string
@property({type : Object}) Cancel: t.Name
render() { return html`vendeur-annonces-id-page`; }}
