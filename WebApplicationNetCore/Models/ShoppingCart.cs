using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNetCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationNetCore.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        //to use in startup.cs --->  services.AddScoped<ShoppingCart, CategoryRepository>();
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            //ISession --> using Microsoft.AspNetCore.Http;

            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; //using Microsoft.Extensions.DependencyInjection;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            var cart = new ShoppingCart(context) { ShoppingCartId = cartId };

            return cart;
        }

        public void AddToCart(Pie pie, int amount)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems
                .SingleOrDefault(s => s.PieId == pie.PieId && s.ShoppingcartId == ShoppingCartId);

            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingcartId = ShoppingCartId,
                    PieId = pie.PieId,
                    Amount = 1
                };

                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems
                .SingleOrDefault(s => s.PieId == pie.PieId && s.ShoppingcartId == ShoppingCartId);

            var localAmount = 0;
            
            if(shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingcartId == ShoppingCartId).Include(p => p.Pie).ToList());
        }

        public void ClearCart()
        {
            var carItems = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingcartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(carItems);

            _appDbContext.SaveChanges();
        }


        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingcartId == ShoppingCartId).Sum(p => p.Pie.Price * p.Amount);
            return total;
        }

    }
}
