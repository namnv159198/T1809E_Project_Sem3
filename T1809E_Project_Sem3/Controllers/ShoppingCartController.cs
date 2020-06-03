using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T1809E_Project_Sem3.Models;

namespace T1809E_Project_Sem3.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public const String ShoppingCartSession = "SHOPPING_CART";
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddItem(int? id)
        {
            var existingProduct = db.Products.FirstOrDefault(m => m.Id == id);
            if (existingProduct == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (Session[ShoppingCartSession] == null)
            {
                List<Cart> listCart = new List<Cart>
                {
                    new Cart(existingProduct,1)
                };
                Session[ShoppingCartSession] = listCart;
            }
            else
            {
                List<Cart> listCart = (List<Cart>)Session[ShoppingCartSession];
                int checkExistingProduct = CheckExistingProduct(id);
                if (checkExistingProduct == -1)
                {
                    listCart.Add(new Cart(existingProduct, 1));
                }
                else
                {
                    listCart[checkExistingProduct].Quantity++;
                }
                Session[ShoppingCartSession] = listCart;
            }

            return View("Index");
        }
        public ActionResult UpdateCart(int productID, int quantity)
        {
            var existingProduct = db.Products.FirstOrDefault(m => m.Id == productID);

            if (existingProduct == null)
            {
                return new HttpNotFoundResult();
            }
            List<Cart> listCart = (List<Cart>)Session[ShoppingCartSession];
            for (int i = 0; i < listCart.Count; i++)
            {
                if (listCart[i].Product.Id == productID)
                {
                    listCart[i].Quantity = quantity;
                }
            }
            Session[ShoppingCartSession] = listCart;
            return Redirect("Index");
        }
        private int CheckExistingProduct(int? id)
        {
            List<Cart> listCart = (List<Cart>)Session[ShoppingCartSession];
            for (int i = 0; i < listCart.Count; i++)
            {
                if (listCart[i].Product.Id == id) return i;
            }

            return -1;
        }
    }
}