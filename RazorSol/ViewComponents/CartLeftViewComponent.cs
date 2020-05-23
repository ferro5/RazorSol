using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RazorSol.Models;

namespace RazorSol.ViewComponents
{
    [ViewComponent(Name = "CartLeft")]
    public class CartLeftViewComponent:ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessionCart = HttpContext.Session.GetString("cart");
            ViewBag.Total = 0;
            if (sessionCart != null)
            {
                List<Item> cart = JsonConvert.DeserializeObject<List<Item>>(sessionCart);
                ViewBag.Total = cart.Sum(it => it.product.Price * it.Quantity);
                ViewBag.CountItems = cart.Count;

            }


            return View("Index");
        }
    }
}
