using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_Annonces_Id_Edit_Page_GET : IPage<Vendeur_Annonces_Id_Edit_Page>
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_Edit_Page
    {
        public Vendeur_Annonces_Id_Edit Data;
        public Form<Vendeur_Annonces_Id_Edit_Page_Form_POST, Vendeur_Annonces_Id_Edit_Page_Form_POSTResponse> Form;
        public IEnumerable<string> Categories;

    }

    public class Vendeur_Annonces_Id_Edit_PageHandler : MessageHandler<Vendeur_Annonces_Id_Edit_Page_GET, Vendeur_Annonces_Id_Edit_Page>
    {
        private readonly IExecuteHandler executeHandler;
        private readonly CategoryService categoryService;

        public Vendeur_Annonces_Id_Edit_PageHandler(IExecuteHandler executeHandler, CategoryService categoryService)
        {
            this.executeHandler = executeHandler;
            this.categoryService = categoryService;
        }

        public override async Task<Vendeur_Annonces_Id_Edit_Page> ExecuteAsync(Vendeur_Annonces_Id_Edit_Page_GET message)
        {
            var page = new Vendeur_Annonces_Id_Edit_Page();

            page.Data = await executeHandler.ExecuteAsync(new Vendeur_Annonces_Id_Edit_GET() { Id = message.Id });
            page.Form = new Form<Vendeur_Annonces_Id_Edit_Page_Form_POST, Vendeur_Annonces_Id_Edit_Page_Form_POSTResponse>();
            page.Categories = categoryService.GetCategories();

            return page;
        }
    }

}