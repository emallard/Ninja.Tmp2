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

            let html = '';
            html += links(_page);

            document.getElementById('content').innerHTML = html;
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
                //document.location.search = '?q=' + response['href'];
            }
        }

        function links(page)
        {
            let html = '';
            let keys = Object.keys(page);
            for (let k of keys) {
                console.log('page property : ' + k);
                if (page[k]['href'] != null)
                    html += '<a href=""' + '?q=' + page[k]['href'] + '"">' + k + '</href><br/>'
            }
            return html;
        }
    </script>
</body>
</page>
";


            await Task.CompletedTask;
            return new HtmlResponse()
            {
                Html = html
            };
        }
    }
}