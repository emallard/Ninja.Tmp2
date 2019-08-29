import { LitElement, html, property, customElement } from "lit-element"
import { InitPage } from './initPage';
@customElement('annonces-page')
class Annonces_PAGEComponent extends LitElement{
@property({type : Array}) Items: t.Name[]
render() { return html`annonces-page`; }}
