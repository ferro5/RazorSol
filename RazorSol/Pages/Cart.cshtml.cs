using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorSol.Models;

namespace RazorSol.Pages
{
    public class CartModel : PageModel
    {
        private readonly RazorContext _context;
        public List<Item> cart { get; set; }
        public decimal Total { get; set; }

        public CartModel(RazorContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Total = 0;
            string sessionCart = HttpContext.Session.GetString("cart");
            if (sessionCart!=null)
            {
                cart = JsonConvert.DeserializeObject<List<Item>>(sessionCart);
                Total = cart.Sum(it => it.product.Price * it.Quantity);
            }
        }
        public IActionResult OnGetBuyNow(int id)
        {

            string sessionCart = HttpContext.Session.GetString("cart");
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            Photo photo = _context.Photos.FirstOrDefault(ph => ph.Status && ph.Featured);
            string photoName = photo == null ? "no-image.png" : photo.Name;
            if (sessionCart == null)
            {
                List<Item>items = new List<Item>();
              items.Add(new Item
                {
                   product = new ProductCart
                   {
                       Id = product.Id,
                       Name = product.Name,
                       Price = product.Price,
                       Photo = photoName

                    },
                    Quantity = 1
               });
              
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(items));
            }
            else
            {
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
                int index = Exists(id, items);
                if (index==-1)
                {
                    items.Add(new Item
                    {
                        product = new ProductCart
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Price = product.Price,
                            Photo = photoName

                        },
                        Quantity = 1
                    });
                }
                else
                {
                    items[index].Quantity++;
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(items));
            }
            return RedirectToPage("Cart");
        }

        public IActionResult OnPost(int[]quantity)
        {
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>
                (HttpContext.Session.GetString("cart"));
            for (int i = 0; i < quantity.Length; i++)
            {
                items[i].Quantity = quantity[i];
            }
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(items));
            return RedirectToPage("Cart");
        }
        public IActionResult OnGetRemove(int id)
        {
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
            int index = Exists(id, items);
            items.RemoveAt(index);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(items));
            return RedirectToPage("Cart");
        }

        public IActionResult OnGetCheckout()
        {
            string username = HttpContext.Session.GetString("username");
            if (username==null)
            {
                return RedirectToPage("Login");
            }
            else
            {
                return RedirectToPage("Thanks for register");
            }
        }
        private int Exists(int id,List<Item>items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].product.Id==id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}