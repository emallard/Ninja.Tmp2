using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore.Page;

namespace CocoriCore.LeBonCoin.Api
{
    public class Graph_GET : IMessage<SvgResponse>
    {
        public string Q;
    }


    public class Graph_GETHandler : MessageHandler<Graph_GET, SvgResponse>
    {
        private readonly PageGraphBuilder builder;
        private readonly PageGraphFormatter formatter;

        public Graph_GETHandler(PageGraphBuilder builder, PageGraphFormatter formatter)
        {
            this.builder = builder;
            this.formatter = formatter;
        }

        public override async Task<SvgResponse> ExecuteAsync(Graph_GET message)
        {
            await Task.CompletedTask;

            string svg = "";
            Func<PageNode, bool> predicate = x => true; ;
            if (message.Q == "users")
            {
                predicate = x => x.ParameterizedUrl == "/api"
                              || x.ParameterizedUrl.StartsWith("/api/users");
            }

            var assembly = CocoriCore.LeBonCoin.AssemblyInfo.Assembly;
            var graph = builder.Build(assembly, predicate);
            svg = formatter.LinksAndForms(graph);


            return new SvgResponse()
            {
                Svg = svg
            };
        }
    }
}