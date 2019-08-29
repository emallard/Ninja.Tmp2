using System;
using System.Linq;
using System.Reflection;
using CocoriCore;
using CocoriCore.Page;
using Xunit;

namespace CocoriCore.LeBonCoin.FrontGenerator
{
    public class FrontGeneratorSammyJs
    {
        [Fact]
        public void Main()
        {
            Console.WriteLine("Front Generator starts.");

            var generator = new SammyJsGenerator(
                new SammyJsGeneratorOptions()
                {
                    OutputPath = "../../../../CocoriCore.LeBonCoin.Front/sammyjs"
                },
                new PageInspector(CocoriCore.LeBonCoin.Api.RouterConfiguration.Options()),
                new TypescriptFormatter());
            generator.Generate();
        }
    }
}
