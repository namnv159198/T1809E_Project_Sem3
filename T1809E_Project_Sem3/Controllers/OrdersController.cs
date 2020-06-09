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
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index(string sortOrder, int? status, int? gender, int? customer_type, string searchStringName, string searchStringEmail, string searchStringAddress, string currentFilter, int? page, DateTime? start, DateTime? end)
        {
            var order = db.Orders.AsQueryable();
            if (searchStringName != null || searchStringEmail != null || searchStringAddress != null)
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchStringName;
            if (!string.IsNullOrEmpty(searchStringName))
            {
                order = order.Where(s => s.CustomerName.Contains(searchStringName));
                if (!string.IsNullOrEmpty(searchStringEmail))
                {
                    order = order.Where(s => s.Email.Contains(searchStringEmail));
                }
                if (!string.IsNullOrEmpty(searchStringAddress))
                {
                    order = order.Where(s => s.Address.Contains(searchStringAddress));
                }
            }
            else
            {
                ViewBag.CurrentFilter = searchStringEmail;
                if (!string.IsNullOrEmpty(searchStringEmail))
                {
                    order = order.Where(s => s.Email.Contains(searchStringEmail));
                    if (!string.IsNullOrEmpty(searchStringAddress))
                    {
                        order = order.Where(s => s.Address.Contains(searchStringAddress));
                    }
                }
                else
                {
                    ViewBag.CurrentFilter = searchStringAddress;
                    if (!string.IsNullOrEmpty(searchStringAddress))
                    {
                        order = order.Where(s => s.Address.Contains(searchStringAddress));
                    }
                }
            }
            if (status.HasValue)
            {
                ViewBag.Status = status;
                order = order.Where(p => (int)p.Status == status.Value);
            }
           
            if (start != null)
            {
                var startDate = start.GetValueOrDefault().Date;
                startDate = startDate.Date + new TimeSpan(0, 0, 0);
                order = order.Where(p => p.CreatedAt >= startDate);
            }
            if (end != null)
            {
                var endDate = end.GetValueOrDefault().Date;
                endDate = endDate.Date + new TimeSpan(23, 59, 59);
                order = order.Where(p => p.CreatedAt <= endDate);
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
                    order = order.OrderBy(p => p.CustomerName);
                    break;
                case "name-desc":
                    order = order.OrderByDescending(p => p.CustomerName);
                    break;
                case "date-asc":
                    order = order.OrderBy(p => p.CreatedAt);
                    break;
                case "date-desc":
                    order = order.OrderByDescending(p => p.CreatedAt);
                    break;
                case "quantity-asc":
                    order = order.OrderBy(p => p.TotalPrice);
                    break;
                case "quantity-desc":
                    order = order.OrderByDescending(p => p.TotalPrice);
                    break;
               
                default:
                    order = order.OrderByDescending(p => p.CreatedAt);
                    ViewBag.SortIcon = "fa fa-sort";
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(order.ToPagedList(pageNumber, pageSize));
        }

        // GET: Orders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Address");
            ViewBag.UpdatedById = new SelectList(db.Users, "Id", "Address");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TotalPrice,Discount,CustomerName,Address,Phone,Email,Gender,CreatedById,UpdatedById,CreatedAt,UpdatedAt,deletedAt,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.Id = "Order" + DateTime.Now.Millisecond;
                order.CreatedAt = DateTime.Now;
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Address", order.CreatedById);
            ViewBag.UpdatedById = new SelectList(db.Users, "Id", "Address", order.UpdatedById);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Address", order.CreatedById);
            ViewBag.UpdatedById = new SelectList(db.Users, "Id", "Address", order.UpdatedById);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TotalPrice,Discount,CustomerName,Address,Phone,Email,Gender,CreatedById,UpdatedById,CreatedAt,UpdatedAt,deletedAt,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Address", order.CreatedById);
            ViewBag.UpdatedById = new SelectList(db.Users, "Id", "Address", order.UpdatedById);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
