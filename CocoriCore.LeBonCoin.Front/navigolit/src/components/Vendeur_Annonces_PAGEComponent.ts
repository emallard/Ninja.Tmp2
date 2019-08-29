import { LitElement, html, property, customElement } from "lit-element"
import { InitPage } from './initPage';
@customElement('vendeur-annonces-page')
class Vendeur_Annonces_PAGEComponent extends LitElement{
@property({type : Array}) Annonces: t.Name[]
render() { return html`vendeur-annonces-page`; }}
