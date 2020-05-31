using PagedList;
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
        public ActionResult Index(string sortOrder, int? status, int? gender, int? customer_type, string searchStringName, string searchStringEmail, string searchStringAddress, string currentFilter, int? page)
        {
            var customers = db.UserCustomerViewModels.AsQueryable();
            if (searchStringName != null || searchStringEmail != null || searchStringAddress != null)
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchStringName;
            if (!string.IsNullOrEmpty(searchStringName))
            {
                customers = customers.Where(s => s.UserName.Contains(searchStringName));
            }
            else
            {
                ViewBag.CurrentFilter = searchStringEmail;
                if (!string.IsNullOrEmpty(searchStringEmail))
                {
                    customers = customers.Where(s => s.Email.Contains(searchStringEmail));
                }
                else
                {
                    ViewBag.CurrentFilter = searchStringAddress;
                    if (!string.IsNullOrEmpty(searchStringAddress))
                    {
                        customers = customers.Where(s => s.Address.Contains(searchStringAddress));
                    }
                }
            }
            if (status.HasValue)
            {
                ViewBag.Status = status;
                customers = customers.Where(p => (int)p.Status == status.Value);
            }
            if (gender.HasValue)
            {
                ViewBag.Status = status;
                customers = customers.Where(p => (int)p.Gender == gender.Value);
            }
            if (customer_type.HasValue)
            {
                ViewBag.Status = status;
                customers = customers.Where(p => (int)p.Customer_Type == customer_type.Value);
            }
            if (string.IsNullOrEmpty(sortOrder) || sortOrder.Equals("date-asc"))
            {
                ViewBag.DateSort = "date-desc";
                ViewBag.NameSort = "name-desc";
                ViewBag.Total_Quantity_PurchasedSort = "quantity-desc";
                ViewBag.Total_Money_PurchasedSort = "money-desc";
                ViewBag.Total_PurchasedSort = "purchased-desc";
                ViewBag.SortIcon = "fa fa-sort-asc";
            }
            else if (sortOrder.Equals("date-desc"))
            {
                ViewBag.DateSort = "date-asc";
                ViewBag.SortIcon = "fa fa-sort-desc";
            }
            else if (sortOrder.Equals("name-asc"))
            {
                ViewBag.NameSort = "name-desc";
                ViewBag.SortIcon = "fa fa-sort-asc";
            }
            else if (sortOrder.Equals("name-desc"))
            {
                ViewBag.NameSort = "name-asc";
                ViewBag.SortIcon = "fa fa-sort-desc";
            }
            else if (sortOrder.Equals("quantity-asc"))
            {
                ViewBag.Total_Quantity_PurchasedSort = "quantity-desc";
                ViewBag.SortIcon = "fa fa-sort-asc";
            }
            else if (sortOrder.Equals("quantity-desc"))
            {
                ViewBag.Total_Quantity_PurchasedSort = "quantity-asc";
                ViewBag.SortIcon = "fa fa-sort-desc";
            }
            else if (sortOrder.Equals("money-asc"))
            {
                ViewBag.Total_Money_PurchasedSort = "money-desc";
                ViewBag.SortIcon = "fa fa-sort-asc";
            }
            else if (sortOrder.Equals("money-desc"))
            {
                ViewBag.Total_Money_PurchasedSort = "money-asc";
                ViewBag.SortIcon = "fa fa-sort-desc";
            }
            else if (sortOrder.Equals("purchased-asc"))
            {
                ViewBag.Total_PurchasedSort = "purchased-desc";
                ViewBag.SortIcon = "fa fa-sort-asc";
            }
            else if (sortOrder.Equals("purchased-desc"))
            {
                ViewBag.Total_PurchasedSort = "purchased-asc";
                ViewBag.SortIcon = "fa fa-sort-desc";
            }

            switch (sortOrder)
            {
                case "name-asc":
                    customers = customers.OrderBy(p => p.UserName);
                    break;
                case "name-desc":
                    customers = customers.OrderByDescending(p => p.UserName);
                    break;
                case "date-asc":
                    customers = customers.OrderBy(p => p.CreatedAt);
                    break;
                case "date-desc":
                    customers = customers.OrderByDescending(p => p.CreatedAt);
                    break;
                case "quantity-asc":
                    customers = customers.OrderBy(p => p.Total_Quantity_Purchased);
                    break;
                case "quantity-desc":
                    customers = customers.OrderByDescending(p => p.Total_Quantity_Purchased);
                    break;
                case "money-asc":
                    customers = customers.OrderBy(p => p.Total_Money_Purchased);
                    break;
                case "money-desc":
                    customers = customers.OrderByDescending(p => p.Total_Money_Purchased);
                    break;
                case "purchased-asc":
                    customers = customers.OrderBy(p => p.Total_Purchased);
                    break;
                case "purchased-desc":
                    customers = customers.OrderByDescending(p => p.Total_Purchased);
                    break;
                default:
                    customers = customers.OrderByDescending(p => p.CreatedAt);
                    ViewBag.SortIcon = "fa fa-sort";
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(customers.ToPagedList(pageNumber, pageSize));
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
