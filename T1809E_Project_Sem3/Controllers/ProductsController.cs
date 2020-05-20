using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T1809E_Project_Sem3.Models;

namespace T1809E_Project_Sem3.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products1
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.category).Include(p => p.CreateBy).Include(p => p.DeleteBy).Include(p => p.UpdateBy);
            return View(products.ToList());
        }

        // GET: Products1/Details/5
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

        // GET: Products1/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name");
            ViewBag.CreateById = new SelectList(db.Users, "Id", "Email");
            ViewBag.DeleteById = new SelectList(db.Users, "Id", "Email");
            ViewBag.UpdateById = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Products1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Status,Description,Thumbnails,Price,Discount,CreateAt,CategoryID,CreateById,UpdateById,DeleteById")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", product.CategoryID);
            ViewBag.CreateById = new SelectList(db.Users, "Id", "Email", product.CreateById);
            ViewBag.DeleteById = new SelectList(db.Users, "Id", "Email", product.DeleteById);
            ViewBag.UpdateById = new SelectList(db.Users, "Id", "Email", product.UpdateById);
            return View(product);
        }

        // GET: Products1/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", product.CategoryID);
            ViewBag.CreateById = new SelectList(db.Users, "Id", "Email", product.CreateById);
            ViewBag.DeleteById = new SelectList(db.Users, "Id", "Email", product.DeleteById);
            ViewBag.UpdateById = new SelectList(db.Users, "Id", "Email", product.UpdateById);
            return View(product);
        }

        // POST: Products1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Status,Description,Thumbnails,Price,Discount,CreateAt,CategoryID,CreateById,UpdateById,DeleteById")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", product.CategoryID);
            ViewBag.CreateById = new SelectList(db.Users, "Id", "Email", product.CreateById);
            ViewBag.DeleteById = new SelectList(db.Users, "Id", "Email", product.DeleteById);
            ViewBag.UpdateById = new SelectList(db.Users, "Id", "Email", product.UpdateById);
            return View(product);
        }

        // GET: Products1/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Products1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
