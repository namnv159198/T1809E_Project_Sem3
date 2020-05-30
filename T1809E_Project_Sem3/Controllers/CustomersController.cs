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
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.UserCustomerViewModels.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCustomerViewModel userCustomerViewModel = db.UserCustomerViewModels.Find(id);
            if (userCustomerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userCustomerViewModel);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCustomerViewModel userCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                var idnumber = db.UserCustomerViewModels.Count() + 1;
                userCustomerViewModel.Id = "Customer" + idnumber;
                userCustomerViewModel.CreatedAt = DateTime.Now;
                userCustomerViewModel.Status = UserCustomerViewModel.EnumStatus.Active;
                db.UserCustomerViewModels.Add(userCustomerViewModel);
                db.SaveChanges();
                TempData["message"] = "Create";
                return RedirectToAction("Index");
            }
            else { TempData["message"] = "Fail"; }
            return View(userCustomerViewModel);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCustomerViewModel userCustomerViewModel = db.UserCustomerViewModels.Find(id);
            if (userCustomerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userCustomerViewModel);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Email,Address,Phonenumber,Gender,Total_Quantity_Purchased,Total_Money_Purchased,Customer_Type,Status,Total_Purchased")] UserCustomerViewModel userCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCustomerViewModel).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = "Edit";
                return RedirectToAction("Index");
            }
            else { TempData["message"] = "Fail"; }
            return View(userCustomerViewModel);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCustomerViewModel userCustomerViewModel = db.UserCustomerViewModels.Find(id);
            if (userCustomerViewModel == null)
            {
                return HttpNotFound();
            }
            db.UserCustomerViewModels.Remove(userCustomerViewModel);
            db.SaveChanges();
            TempData["message"] = "Delete";
            return View(userCustomerViewModel);
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
