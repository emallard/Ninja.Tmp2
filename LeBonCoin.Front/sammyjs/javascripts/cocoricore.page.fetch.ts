
class Form<T, R> {
    method: string;
    parameterizedUrl: string;
}

function fillParameterizedUrl(url: string, obj: object): string {
    var keys = Object.keys(obj);
    for (let k of keys) {
        url = url.replace("/:" + k + "/g", obj[k]);
    }
    return url;
}

abstract class Page {

    abstract PageUrl: string;

    async onInit() {
        await this.fetchAndFill(this.PageUrl);
        await this.postInit();
    }

    abstract postInit(): void;

    async fetchAndFill(url: string): Promise<void> {
        console.log('fetch page data : ' + url);
        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        let response = await fetch(url,
            {
                headers: myHeaders,
                method: "GET",
            });

        let txt = await response.text();

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
    }

    async submit<T extends object, R extends object>(submit: Form<T, R>, body: T): Promise<R> {
        let url: string = fillParameterizedUrl(submit.parameterizedUrl, body);
        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        let fetchResponse = await fetch(url,
            {
                headers: myHeaders,
                method: submit.method,
                //mode: 'cors',
                //credentials: 'include'
            });

        let txt = await fetchResponse.text();
        if (txt.length > 0) {
            var obj = JSON.parse(txt);
            if (obj.Redirect != undefined)
                location.href = "#/" + obj.Redirect;
            return obj;
        }
    }
}

