using System;
using System.Threading.Tasks;
using CocoriCore.Page;
using FluentAssertions;
using Xunit;

namespace CocoriCore.LeBonCoin
{
    public class Edit__Test : TestBase
    {

        [Fact]
        public void Test()
        {
            var user = CreateUser("vendeur");
            /*
            user.Play(new EnTantQueVendeur())
                .Submit2(p => p.Data.Message,
                         m => m)
                .Follow(p => p.Data.LienAnnonce);
            */
        }
    }
}