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

            var dashboard =
            user.Display(new EditPage4.PageGet() { Id = Guid.NewGuid() });
        }
    }
}