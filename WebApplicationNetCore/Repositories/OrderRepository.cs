using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNetCore.Interfaces;
using WebApplicationNetCore.Models;

namespace WebApplicationNetCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ShoppingCart _shoppingCart;


        //in statup.cs ==>  services.AddScoped<IOrderRepository, OrderRepository>();
        public OrderRepository(AppDbContext dbContext, ShoppingCart shoppingCart)
        {
            _dbContext = dbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _dbContext.Orders.Add(order);

            var items = _shoppingCart.ShoppingCartItems;
                
            foreach(var item in items)
            {
                var detail = new OrderDetail {
                    OrderId = order.OrderId,
                    PieId = item.PieId,
                    Amount = item.Amount,
                    Price = item.Pie.Price
                };

                _dbContext.OrderDetails.Add(detail);
            }

            _dbContext.SaveChanges();

        }


    }
}
