using System;
using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin.Api
{
    public class HtmlMessage : IMessage<HtmlResponse>
    {
        public string Q;
    }

    public class HtmlResponse
    {
        public string Html;
    }

    public class HtmlMessageHandler : MessageHandler<HtmlMessage, HtmlResponse>
    {
        public override async Task<HtmlResponse> ExecuteAsync(HtmlMessage message)
        {
            var html =
@"

<html>
<body>
    <div id='content'></div>
    <script>
        var _page = null;

        async function init ()
        {
            let myHeaders = new Headers();
            myHeaders.append('Content-Type', 'application/json');
            let pageGet = document.location.search.replace('?q=', '');
            let response = await fetch(pageGet,
                {
                    headers: myHeaders,
                    method: 'GET'
                });

            let txt = await response.text();
            _page = JSON.parse(txt);

            let html = links(_page) + forms(_page);
            document.getElementById('content').innerHTML = html;

            registerOnSubmits(_page);
        }

        init();

        async function call (callObj)
        {
            let myHeaders = new Headers();
            myHeaders.append('Content-Type', 'application/json');
            let response = await fetch('/api/call',
                {
                    headers: myHeaders,
                    method: 'POST',
                    body: JSON.stringify(callObj)
                });

            return await response.json();

        }

        async function pagecall (callObj)
        {
            let response = await call(callObj);
            console.log(response);
            if (response['href'] != null)
            {
                console.log('redirect to : ' + response['href']);
                document.location.search = '?q=' + response['href'];
            }
        }

        function links(page)
        {
            let html = '';
            let keys = Object.keys(page);
            for (let k of keys) {
                if (page[k]['href'] != null)
                {
                    console.log('link : ' + k);
                    html += '<a href=""' + '?q=' + page[k]['href'] + '"">' + k + '</a><br/>'
                }
            }
            return html;
        }

        function forms(page)
        {
            let html = '';
            let keys = Object.keys(page);
            for (let k of keys) {
                if (page[k]['PageMessage'] != null)
                {
                    console.log('form : ' + k);
                    
                    html += '<form id = ""' + k + '"">'
                        + inputs(page[k])
                        + '<button>' + k + '</button>'
                        + '</form>';
                }
            }
            return html;
        }
         
        function inputs(form)
        {
            let html = '';
            let keys = Object.keys(form.Message);
            for (let k of keys) {
                console.log('    input : ' + k);
                html += k + ' : ' + '<input id=""' + k + '""></input><br/>';
            }
            return html;
        }

        function registerOnSubmits(page)
        {
            let keys = Object.keys(page);
            for (let k of keys) {
                if (page[k]['PageMessage'] != null)
                {
                    registerOnSubmit(k, page[k]);
                }
            }
        }

        function registerOnSubmit(idForm, form)
        {
            document.getElementById(idForm).addEventListener('submit', async (evt) => 
            {
                evt.preventDefault();
                let keys = Object.keys(form.Message);
                for (let k of keys) {
                    form.Message[k] = document.getElementById(k).value;
                }
                console.log('submit ' + idForm, form.Message);
                pagecall(form);
            });
        }

    </script>
</body>
</html>
";


            await Task.CompletedTask;
            return new HtmlResponse()
            {
                Html = html
            };
        }
    }
}