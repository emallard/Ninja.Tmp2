var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
class Form {
}
function fillParameterizedUrl(url, obj) {
    var keys = Object.keys(obj);
    for (let k of keys) {
        url = url.replace("/:" + k + "/g", obj[k]);
    }
    return url;
}
class Page {
    onInit() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.fetchAndFill(this.PageUrl);
            yield this.postInit();
        });
    }
    fetchAndFill(url) {
        return __awaiter(this, void 0, void 0, function* () {
            console.log('fetch page data : ' + url);
            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");
            let response = yield fetch(url, {
                headers: myHeaders,
                method: "GET",
            });
            let txt = yield response.text();
            console.log('page data as text : ' + txt);
            if (txt.length > 0) {
                var obj = JSON.parse(txt);
                var keys = Object.keys(obj);
                for (let k of keys) {
                    console.log('page property : ' + k);
                    this[k] = obj[k];
                }
            }
            console.log(this);
        });
    }
    submit(submit, body) {
        return __awaiter(this, void 0, void 0, function* () {
            let url = fillParameterizedUrl(submit.parameterizedUrl, body);
            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");
            let fetchResponse = yield fetch(url, {
                headers: myHeaders,
                method: submit.method,
            });
            let txt = yield fetchResponse.text();
            if (txt.length > 0) {
                var obj = JSON.parse(txt);
                if (obj.Redirect != undefined)
                    location.href = "#/" + obj.Redirect;
                return obj;
            }
        });
    }
}
class Users_Connexion_POST {
}
class Users_Connexion_POSTResponse {
}
class Users_MotDePasseOublie_POST {
}
class Users_MotDePasseOublie_POSTResponse {
}
class MenuUtilisateur {
}
class Accueil_PAGE extends Page {
    constructor() {
        super(...arguments);
        this.PageUrl = '/api/';
    }
}
class Users_Connexion_PAGE extends Page {
    constructor() {
        super(...arguments);
        this.PageUrl = '/api/users/connexion';
    }
}
class Users_MotDePasseOublie_PAGE extends Page {
    constructor() {
        super(...arguments);
        this.PageUrl = '/api/users/mot-de-passe-oublie';
    }
}
class Vendeur_Dashboard_PAGE extends Page {
    constructor() {
        super(...arguments);
        this.PageUrl = '/api/vendeur';
    }
}
class Accueil_PAGEComponent extends Accueil_PAGE {
    constructor() {
        super();
    }
    postInit() {
        return __awaiter(this, void 0, void 0, function* () {
            document.getElementById("Connexion").setAttribute("href", this.Connexion);
        });
    }
}
class Users_Connexion_PAGEComponent extends Users_Connexion_PAGE {
    constructor() {
        super();
    }
    postInit() {
        return __awaiter(this, void 0, void 0, function* () {
            document.getElementById("motDePasseOublie").setAttribute("href", this.MotDePasseOublie);
            document.getElementById('form').addEventListener('submit', (evt) => __awaiter(this, void 0, void 0, function* () {
                evt.preventDefault();
                yield this.submit(this.Form, {
                    Email: document.getElementById("email").value,
                    Password: document.getElementById("password").value,
                });
                return false;
            }));
        });
    }
}
class Users_MotDePasseOublie_PAGEComponent extends Users_MotDePasseOublie_PAGE {
    constructor() {
        super();
    }
    postInit() {
        return __awaiter(this, void 0, void 0, function* () {
            document.getElementById('form').addEventListener('submit', (evt) => __awaiter(this, void 0, void 0, function* () {
                evt.preventDefault();
                /*
                await this.submit(this.Form,
                    {
                        Email: (<HTMLInputElement>document.getElementById("email")).value
                    });
                */
                return false;
            }));
        });
    }
}
class Vendeur_Dashboard_PAGEComponent extends Vendeur_Dashboard_PAGE {
    constructor() {
        super();
    }
    postInit() {
        return __awaiter(this, void 0, void 0, function* () {
        });
    }
}
//# sourceMappingURL=tsbuild.js.map