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
          
            return View();
        }
        public ActionResult Men(int? page)
        {
            var Product = db.Products.Where(m => m.category.Name == "Men");
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(Product.OrderBy(p => p.Id).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Women(int? page)
        {

            var Product = db.Products.Where(m => m.category.Name == "Women");

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Product.OrderBy(p => p.Id).ToPagedList(pageNumber, pageSize));
        }
    }
}