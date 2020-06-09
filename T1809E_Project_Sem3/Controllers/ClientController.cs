using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using T1809E_Project_Sem3.Models;
namespace T1809E_Project_Sem3.Controllers
{
    public class ClientController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Client
        public ActionResult Index()
        {
            var product = db.Products.Include(p => p.category).Include(p => p.CreateBy).Include(p => p.DeleteBy).Include(p => p.UpdateBy);
            return View(product);
        }
        //public ActionResult Men(int? page, String sortOrder, string searchString)
        //{
        //    var product = db.Products.Include(p => p.category).Include(p => p.CreateBy).Include(p => p.DeleteBy).Include(p => p.UpdateBy);
        //    product = product.Where(m => m.category.Name == "Men").AsQueryable();
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        product = product.Where(s => s.Name.Contains(searchString));
        //    }

        //    switch (sortOrder)
        //    {
        //        case "name-asc":
        //            product = product.OrderBy(p => p.Name);
        //            break;
        //        case "name-desc":
        //            product = product.OrderByDescending(p => p.Name);
        //            break;
        //        case "price-asc":
        //            product = product.OrderBy(p => p.Price);
        //            break;
        //        case "price-desc":
        //            product = product.OrderByDescending(p => p.Price);
        //            break;
        //        default:
        //            product = product.OrderBy(x => x.CreateAt);
        //            break;

        //    }

        //    int pageSize = 6;
        //    int pageNumber = (page ?? 1);
        //    return View(product.ToPagedList(pageNumber, pageSize));
        //}
        //public ActionResult Women(int? page, string sortOrder, string searchString)
        //{
        //    var product = db.Products.Include(p => p.category).Include(p => p.CreateBy).Include(p => p.DeleteBy).Include(p => p.UpdateBy);
        //    product = product.Where(m => m.category.Name == "Women").AsQueryable();
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        product = product.Where(s => s.Name.Contains(searchString));
        //    }

        //    switch (sortOrder)
        //    {
        //        case "name-asc":
        //            product = product.OrderBy(p => p.Name);
        //            break;
        //        case "name-desc":
        //            product = product.OrderByDescending(p => p.Name);
        //            break;
        //        case "price-asc":
        //            product = product.OrderBy(p => p.Price);
        //            break;
        //        case "price-desc":
        //            product = product.OrderByDescending(p => p.Price);
        //            break;
        //        default:
        //            product = product.OrderBy(x => x.CreateAt);
        //            break;

        //    }

        //    int pageSize = 6;
        //    int pageNumber = (page ?? 1);
        //    return View(product.ToPagedList(pageNumber, pageSize));
        //}
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult Checkout()
        {

            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
                return View(product);
        }

        public ActionResult ViewCart()
        {

            return View();
        }
        public ActionResult Shop(string searchString,int? category)
        {
            var listCategory = db.Categories.ToList();
            SelectList Categorylist = new SelectList(listCategory, "ID", "Name");
            ViewBag.Categorylist = Categorylist;
            var product = db.Products.Include(p => p.category).Include(p => p.CreateBy).Include(p => p.DeleteBy).Include(p => p.UpdateBy);
            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.Name.Contains(searchString));
            }
            if (!product.Any())
            {
                TempData["message"] = "NotFound";
            }
            return View(product);
         
        }
        public ActionResult Blog()
        {

            return View();
        }
       
        
        [HttpGet]
        public ActionResult TrackOrder(string OrderId, string OrderEmail)
        {
            if (OrderId != null || OrderEmail != null )
            {
                Order order = db.Orders.Find(OrderId);
                TempData["status"] = "fail";
                if (order != null)
                {
                    TempData["status"] = "success";
                    return View(order);
                }
                return View();
            }
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}