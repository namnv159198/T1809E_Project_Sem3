using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T1809E_Project_Sem3.Models;

namespace T1809E_Project_Sem3.Controllers
{
    public class ChartController : Controller
    {
		private ApplicationDbContext db = new ApplicationDbContext();
		// GET: Chart
		public ActionResult Index()
		{
			return View();
		}
		public static double num2;
		public void AddSum(IQueryable<Order> orders)
		{
			num2 = 0;
			double num1;
			double num = 0;
			foreach (var o in orders)
			{
				num1 = o.TotalPrice;
				num += num1;
			}
			num2 = num;
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
			AddSum(ordersJan);
			dataPoints.Add(new ModelsChart.DataPoint(01, num2));
			AddSum(ordersFeb);
			dataPoints.Add(new ModelsChart.DataPoint(02, num2));
			AddSum(ordersMar);
			dataPoints.Add(new ModelsChart.DataPoint(03, num2));
			AddSum(ordersApr);
			dataPoints.Add(new ModelsChart.DataPoint(04, num2));
			AddSum(ordersMay);
			dataPoints.Add(new ModelsChart.DataPoint(05, num2));
			AddSum(ordersJun);
			dataPoints.Add(new ModelsChart.DataPoint(06, num2));
			AddSum(ordersJul);
			dataPoints.Add(new ModelsChart.DataPoint(07, num2));
			AddSum(ordersAug);
			dataPoints.Add(new ModelsChart.DataPoint(08, num2));
			AddSum(ordersSep);
			dataPoints.Add(new ModelsChart.DataPoint(09, num2));
			AddSum(ordersOct);
			dataPoints.Add(new ModelsChart.DataPoint(10, num2));
			AddSum(ordersNov);
			dataPoints.Add(new ModelsChart.DataPoint(11, num2));
			AddSum(ordersDec);
			dataPoints.Add(new ModelsChart.DataPoint(12, num2));


			JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
			return Content(JsonConvert.SerializeObject(dataPoints, _jsonSetting), "application/json");
		}
	}
}