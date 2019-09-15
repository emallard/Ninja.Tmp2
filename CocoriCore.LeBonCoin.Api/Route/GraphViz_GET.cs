using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore.Page;

namespace CocoriCore.LeBonCoin.Api
{
    public class GraphViz_GET : IMessage<SvgResponse>
    {
        public string Q;
    }


    public class GraphViz_GETHandler : MessageHandler<GraphViz_GET, SvgResponse>
    {
        private readonly PageGraphBuilder builder;
        private readonly PageGraphFormatter formatter;

        public GraphViz_GETHandler(PageGraphBuilder builder, PageGraphFormatter formatter)
        {
            this.builder = builder;
            this.formatter = formatter;
        }

        public override async Task<SvgResponse> ExecuteAsync(GraphViz_GET message)
        {
            await Task.CompletedTask;

            string svg = "";
            if (message.Q == "1")
            {

            }
            else
            {
                var assembly = CocoriCore.LeBonCoin.AssemblyInfo.Assembly;
                var graph = builder.Build(assembly);
                svg = formatter.LinksAndForms(graph);
            }

            return new SvgResponse()
            {
                Svg = svg
            };
        }
    }
}