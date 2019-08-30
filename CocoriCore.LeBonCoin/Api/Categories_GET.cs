using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace CocoriCore.LeBonCoin
{

    public class Categories_GET : IMessage<Categories_GETResponse>
    {
        public string Texte;
    }

    public class Categories_GETResponse
    {
        public string[] Resultats;
    }


    public class Categories_GETHandler : MessageHandler<Categories_GET, Categories_GETResponse>
    {
        private readonly CategoryService categoryService;

        public Categories_GETHandler(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public override async Task<Categories_GETResponse> ExecuteAsync(Categories_GET command)
        {
            await Task.CompletedTask;
            return new Categories_GETResponse()
            {
                Resultats = categoryService.GetCategories()
            };
        }
    }
}
