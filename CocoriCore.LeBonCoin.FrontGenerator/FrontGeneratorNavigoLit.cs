using System;
using System.Linq;
using System.Reflection;
using CocoriCore;
using CocoriCore.Page;
using Xunit;

namespace CocoriCore.LeBonCoin.FrontGenerator
{
    public class FrontGeneratorNavigoLit
    {
        [Fact]
        public void Main()
        {
            Console.WriteLine("Front Generator starts.");

            new LitElementGenerator(
                new LitElementGeneratorOptions()
                {
                    OutputPath = "../../../../CocoriCore.LeBonCoin.Front/navigolit/src/components"
                },
                new PageInspector(CocoriCore.LeBonCoin.Api.RouterConfiguration.Options()),
                new TypescriptFormatter())
            .Generate();

            new NavigoGenerator(
                new NavigoGeneratorOptions()
                {
                    OutputPath = "../../../../CocoriCore.LeBonCoin.Front/navigolit/src"
                },
                new PageInspector(CocoriCore.LeBonCoin.Api.RouterConfiguration.Options()),
                new TypescriptFormatter())
            .Generate();
        }
    }
}
