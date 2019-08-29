import { LitElement, html, property, customElement } from "lit-element"
import { InitPage } from './initPage';
@customElement('vendeur-nouvelleannonce-page')
class Vendeur_NouvelleAnnonce_PAGEComponent extends LitElement{
@property({type : Array}) Categories: string[]
render() { return html`vendeur-nouvelleannonce-page`; }}
