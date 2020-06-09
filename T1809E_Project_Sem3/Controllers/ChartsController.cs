using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using T1809E_Project_Sem3.Models;

namespace T1809E_Project_Sem3.Controllers
{
    public class ChartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ChartProduct
        public ActionResult Index()
        {
            var listProductIDVsTotal = db.OrderDetails.GroupBy(o => o.ProductId).Select(group => new
            {
                ProductId = group.Key,
                TotalQuantity = group.Sum(o => o.Quantity)
            }).OrderBy(x => x.ProductId);

            var listProductNamevsTotal = from p in db.Products
                join l in listProductIDVsTotal on
                    p.Id equals l.ProductId
                select new
                {
                    ProductName = p.Name,
                    Total = l.TotalQuantity
                };

            foreach (var i in listProductIDVsTotal)
            {
                var k = i.ProductId + "-" + i.TotalQuantity;
            }
            List<ModelsChart.DataPoint> dataPoints = new List<ModelsChart.DataPoint>();

            foreach (var i in listProductIDVsTotal)
            {
                dataPoints.Add(new ModelsChart.DataPoint(i.ProductId,i.TotalQuantity));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }
    }
}