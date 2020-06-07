using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using T1809E_Project_Sem3.Models;

namespace T1809E_Project_Sem3.Models
{
    public class ChartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Chart
        public ActionResult Index()
        {
           
            return View();
        }
		public ContentResult JSON()
		{
			
			List<ModelsChart.DataPoint> dataPoints = new List<ModelsChart.DataPoint>();
			var orders = db.Orders.Where(o => o.CreatedAt.Value.Year == DateTime.Now.Year).Where(o => o.Status == OrderStatus.Order_Completed);
			var ordersJan = orders.Where(o => o.CreatedAt.Value.Month == 1);
			var ordersFeb = orders.Where(o => o.CreatedAt.Value.Month == 2);
			var ordersMar = orders.Where(o => o.CreatedAt.Value.Month == 3);
			var ordersApr = orders.Where(o => o.CreatedAt.Value.Month == 4);
			var ordersMay = orders.Where(o => o.CreatedAt.Value.Month == 5);
			var ordersJun = orders.Where(o => o.CreatedAt.Value.Month == 6);
			var ordersJul = orders.Where(o => o.CreatedAt.Value.Month == 7);
			var ordersAug = orders.Where(o => o.CreatedAt.Value.Month == 8);
			var ordersSep = orders.Where(o => o.CreatedAt.Value.Month == 9);
			var ordersOct = orders.Where(o => o.CreatedAt.Value.Month == 10);
			var ordersNov = orders.Where(o => o.CreatedAt.Value.Month == 11);
			var ordersDec = orders.Where(o => o.CreatedAt.Value.Month == 12);
			decimal num1 = 0;
			decimal num2 = 0;
			foreach (var o in ordersJan)
			{
				num1 = o.TotalPrice;
                num2 += num1;
			}
			dataPoints.Add(new ModelsChart.DataPoint(01, (double)num2));
			num2 = 0;
			foreach (var o in ordersFeb)
			{
				num1 = o.TotalPrice;
				num2 += num1;
			}
			dataPoints.Add(new ModelsChart.DataPoint(02, (double)num2));
			num2 = 0;
			foreach (var o in ordersMar)
			{
				num1 = o.TotalPrice;
				num2 += num1;
			}
			dataPoints.Add(new ModelsChart.DataPoint(03, (double)num2));
			num2 = 0;
			foreach (var o in ordersApr)
			{
				num1 = o.TotalPrice;
				num2 += num1;
			}
			dataPoints.Add(new ModelsChart.DataPoint(04, (double)num2));
			num2 = 0;
			foreach (var o in ordersMay)
			{
				num1 = o.TotalPrice;
				num2 += num1;
			}
			dataPoints.Add(new ModelsChart.DataPoint(05, (double)num2));
			num2 = 0;
			foreach (var o in ordersJun)
			{
				num1 = o.TotalPrice;
				num2 += num1;
			}
			dataPoints.Add(new ModelsChart.DataPoint(06, (double)num2));
			num2 = 0;
			foreach (var o in ordersJul)
			{
				num1 = o.TotalPrice;
				num2 += num1;
			}
			dataPoints.Add(new ModelsChart.DataPoint(07, (double)num2));
			num2 = 0;
			foreach (var o in ordersAug)
			{
				num1 = o.TotalPrice;
				num2 += num1;
			}
			dataPoints.Add(new ModelsChart.DataPoint(08, (double)num2));
			num2 = 0;
			foreach (var o in ordersSep)
			{
				num1 = o.TotalPrice;
				num2 += num1;
			}
			dataPoints.Add(new ModelsChart.DataPoint(09, (double)num2));
			num2 = 0;
			foreach (var o in ordersOct)
			{
				num1 = o.TotalPrice;
				num2 += num1;
			}
			dataPoints.Add(new ModelsChart.DataPoint(10, (double)num2));
			num2 = 0;
			foreach (var o in ordersNov)
			{
				num1 = o.TotalPrice;
				num2 += num1;
			}
			dataPoints.Add(new ModelsChart.DataPoint(11, (double)num2));
			num2 = 0;
			foreach (var o in ordersDec)
			{
				num1 = o.TotalPrice;
				num2 += num1;
			}
			dataPoints.Add(new ModelsChart.DataPoint(12, (double)num2));


			JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
			return Content(JsonConvert.SerializeObject(dataPoints, _jsonSetting), "application/json");
		}
	}
}