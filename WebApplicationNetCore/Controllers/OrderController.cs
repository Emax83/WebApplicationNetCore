using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNetCore.Interfaces;
using WebApplicationNetCore.Models;

namespace WebApplicationNetCore.Controllers
{
    [Authorize] //using Microsoft.AspNetCore.Authorization;
    public class OrderController : Controller
    {

        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            ViewData["Title"] = "Order Checkout";
        }


        public IActionResult CheckOut()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            if (ModelState.IsValid)
            {

                var items = _shoppingCart.GetShoppingCartItems();
                if(items.Count > 0)
                {
                    _orderRepository.CreateOrder(order);
                    _shoppingCart.ClearCart();
                    return RedirectToAction("CheckOutComplete");
                }
                else
                {
                    ModelState.AddModelError("", "Your cart is empty!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Check all fields before");
            }
            return View(order);
        }

        public IActionResult CheckOutComplete()
        {
            ViewBag.Message = "Thank you for your order!";
            return View();
        }

    }
}
