using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace CocoriCore.LeBonCoin
{

    public class Categories_GET : IMessage<Categories>
    {
        public string Texte;
    }

    public class Categories
    {
        public string[] Resultats;
    }


    public class Categories_GETHandler : MessageHandler<Categories_GET, Categories>
    {
        private readonly CategoryService categoryService;

        public Categories_GETHandler(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public override async Task<Categories> ExecuteAsync(Categories_GET command)
        {
            await Task.CompletedTask;
            return new Categories()
            {
                Resultats = categoryService.GetCategories()
            };
        }
    }
}
