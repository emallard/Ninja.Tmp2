import { LitElement, html, property, customElement } from "lit-element"
import { InitPage } from './initPage';
@customElement('accueil-page')
class Accueil_PAGEComponent extends LitElement{
@property({type : Array}) Categories: string[]
render() { return html`accueil-page`; }}
