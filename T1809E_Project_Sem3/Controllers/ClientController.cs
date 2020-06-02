﻿using System;
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
        public ActionResult Men(int? page, String sortOrder, string searchString)
        {
            var product = db.Products.Include(p => p.category).Include(p => p.CreateBy).Include(p => p.DeleteBy).Include(p => p.UpdateBy);
            product = product.Where(m => m.category.Name == "Men").AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name-asc":
                    product = product.OrderBy(p => p.Name);
                    break;
                case "name-desc":
                    product = product.OrderByDescending(p => p.Name);
                    break;
                case "price-asc":
                    product = product.OrderBy(p => p.Price);
                    break;
                case "price-desc":
                    product = product.OrderByDescending(p => p.Price);
                    break;
                default:
                    product = product.OrderBy(x => x.CreateAt);
                    break;

            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(product.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Women(int? page, string sortOrder, string searchString)
        {
            var product = db.Products.Include(p => p.category).Include(p => p.CreateBy).Include(p => p.DeleteBy).Include(p => p.UpdateBy);
            product = product.Where(m => m.category.Name == "Women").AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name-asc":
                    product = product.OrderBy(p => p.Name);
                    break;
                case "name-desc":
                    product = product.OrderByDescending(p => p.Name);
                    break;
                case "price-asc":
                    product = product.OrderBy(p => p.Price);
                    break;
                case "price-desc":
                    product = product.OrderByDescending(p => p.Price);
                    break;
                default:
                    product = product.OrderBy(x => x.CreateAt);
                    break;

            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(product.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult Checkout()
        {

            return View();
        }
        public ActionResult ViewCart()
        {

            return View();
        }
    }
}