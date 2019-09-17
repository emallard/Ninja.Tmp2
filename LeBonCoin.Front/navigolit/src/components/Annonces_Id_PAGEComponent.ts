import { LitElement, html, property, customElement } from "lit-element"
import { InitPage } from './initPage';
@customElement('annonces-id-page')
class Annonces_Id_PAGEComponent extends LitElement{
@property({type : String}) Ville: string
@property({type : String}) Categorie: string
@property({type : String}) Text: string
render() { return html`annonces-id-page`; }}
