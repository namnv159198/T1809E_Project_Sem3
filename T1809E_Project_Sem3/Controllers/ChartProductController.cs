using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using T1809E_Project_Sem3.Models;

namespace T1809E_Project_Sem3.Controllers
{
    public class ChartProductController : Controller
    {
        // GET: ChartProduct
        public ActionResult Index()
        {
            List<ModelsChart.DataPoint> dataPoints = new List<ModelsChart.DataPoint>();

            dataPoints.Add(new ModelsChart.DataPoint("USA", 121));
            dataPoints.Add(new ModelsChart.DataPoint("Great Britain", 67));
            dataPoints.Add(new ModelsChart.DataPoint("China", 70));
            dataPoints.Add(new ModelsChart.DataPoint("Russia", 56));
            dataPoints.Add(new ModelsChart.DataPoint("Germany", 42));
            dataPoints.Add(new ModelsChart.DataPoint("Japan", 41));
            dataPoints.Add(new ModelsChart.DataPoint("France", 42));
            dataPoints.Add(new ModelsChart.DataPoint("South Korea", 21));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
    }
}