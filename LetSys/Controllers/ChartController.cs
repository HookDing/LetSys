using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetSys.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData1(string value)
        {
            var date = DateTime.Parse(value);
            var list =Bll_PayInfo.GetChart1(date);
            return Json(list);
        }
    }
}