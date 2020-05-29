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
        public ActionResult Men()
        {
            var Product = db.Products.Where(m => m.category.Name == "Men");
            return View(Product);
        }
        public ActionResult Women()
        {

            var Product = db.Products.Where(m => m.category.Name == "Women");

            return View(Product);
        }
    }
}