using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore.Page;

namespace CocoriCore.LeBonCoin.Api
{
    public class GraphViz_GET : IMessage<SvgResponse>
    {

    }


    public class GraphViz_GETHandler : MessageHandler<GraphViz_GET, SvgResponse>
    {
        private readonly PageGraphGenerator pageGraphGenerator;

        public GraphViz_GETHandler(PageGraphGenerator pageGraphGenerator)
        {
            this.pageGraphGenerator = pageGraphGenerator;
        }

        public override async Task<SvgResponse> ExecuteAsync(GraphViz_GET message)
        {
            await Task.CompletedTask;
            var assembly = CocoriCore.LeBonCoin.AssemblyInfo.Assembly;
            var dotFile = pageGraphGenerator.GraphViz(assembly);
            var svg = pageGraphGenerator.CmdDot(dotFile);

            return new SvgResponse()
            {
                Svg = svg
            };
        }
    }
}