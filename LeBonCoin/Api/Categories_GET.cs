using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace LeBonCoin
{

    public class Categories_GET : IMessage<string[]>
    {
        public string Texte;
    }


    public class Categories_GETHandler : MessageHandler<Categories_GET, string[]>
    {
        private readonly CategoryService categoryService;

        public Categories_GETHandler(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public override async Task<string[]> ExecuteAsync(Categories_GET command)
        {
            await Task.CompletedTask;
            return categoryService.GetCategories();
        }
    }
}
