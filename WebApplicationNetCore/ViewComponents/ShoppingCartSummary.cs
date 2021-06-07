using Microsoft.AspNetCore.Mvc;
using WebApplicationNetCore.Models;
using WebApplicationNetCore.ViewModels;

namespace WebApplicationNetCore.ViewComponents
{
    public class ShoppingCartSummary : ViewComponent //using Microsoft.AspNetCore.Mvc;
    {
        //_ViewImports ==> @using WebApplicationNetCore.ViewComponents
        //view ==> /Views/shared/components/*nameofviewcomponent*/Default.cshtml
        //using in razor pages ==> @await Component.InvokeAsync("ShoppingCartSummary")


        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke() 
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var viewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(viewModel);
        }
    }
}
