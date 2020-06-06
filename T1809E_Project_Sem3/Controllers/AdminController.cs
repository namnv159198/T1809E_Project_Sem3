﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T1809E_Project_Sem3.Models;

namespace T1809E_Project_Sem3.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            
            return View();
        }
        
        public ActionResult Button()
        {
            return View();
        }
        public ActionResult Fontawesome()
        {
            return View();
        }
       
        public ActionResult Dynamic_Table()
        {
            return View();
        }
        public ActionResult Basic_Table()
        {
            return View();
        }
        public ActionResult Edit_Table()
        {
            return View();
        }
        public ActionResult Responsive_Table()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Homepage()
        {
            ViewBag.totalProduct = db.Products.Count();
            var orders = db.Orders.Where(c => c.CreatedAt == DateTime.Now);
            ViewBag.totalPrice = orders.Sum(o => o.TotalPrice);
            return View();
        }
       
    }
}