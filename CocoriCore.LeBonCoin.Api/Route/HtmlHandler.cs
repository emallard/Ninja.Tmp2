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
        var page = null;

        async function get1 ()
        {
            var myHeaders = new Headers();
            myHeaders.append('Content-Type', 'application/json');
            let response = await fetch('/{q}',
                {
                    headers: myHeaders,
                    method: 'GET'
                });

            let txt = await response.text();
            page = JSON.parse(txt);

            //document.getElementById('content').innerHTML
        }

        get1();

        async function call (callObj)
        {
            var myHeaders = new Headers();
            myHeaders.append('Content-Type', 'application/json');
            let response = await fetch('/api/call',
                {
                    headers: myHeaders,
                    method: 'POST',
                    body: JSON.stringify(callObj)
                });

            let txt = await response.text();
        }

        async function pagecall (callObj)
        {
            var myHeaders = new Headers();
            myHeaders.append('Content-Type', 'application/json');
            let response = await fetch('/api/pagecall',
                {
                    headers: myHeaders,
                    method: 'POST',
                    body: JSON.stringify(callObj)
                });

            let txt = await response.text();
        }
    </script>
</body>
</page>
";
            html = html.Replace("{q}", message.Q);


            await Task.CompletedTask;
            return new HtmlResponse()
            {
                Html = html
            };
        }
    }
}