
export class InitPage {
    async Fill(url: string, obj: object): Promise<void> {
        console.log('fetch page data : ' + url);
        var myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        let response = await fetch(url,
            {
                headers: myHeaders,
                method: 'GET'
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
    }
}