using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        public Cart Cart { get; set; }       //IoC 

        private readonly IServiceManager _manager;


        public CartModel(IServiceManager manager, Cart cartService)
        {
            _manager = manager;
            Cart = cartService;
        }

        public string ReturnUrl { get; set; } = "/";


        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/"; //referans yoksa "/" a git




            //* VARSA OLAN CART'I al YOKSA ÜRET
            //   Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }



        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetOneProduct(productId, false);


            if (product is not null)
            {
                //     Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                //*
                //    HttpContext.Session.SetJson<Cart>("cart", Cart);
            }

            return RedirectToPage(new { returnUrl = returnUrl }); //return url

        }

        //asp-page-handler
        public IActionResult OnPostRemove(int id, string returnUrl)
        {

            //     Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
            //   HttpContext.Session.SetJson<Cart>("cart", Cart);
            return Page();
        }



    }



}