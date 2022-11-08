using Bll;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetSys.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllMod()
        {
            return Json(Bll_Customers.GetAllMod());
        }
        public ActionResult GetMod(int id)
        {
            return Json(Bll_Customers.GetMod(id));
        }
        public ActionResult Insert(string CusName, string CusSex, string CusCard, string CusTel)
        {
            Customers info = new Customers
            {
                CusName = CusName,
                CusSex = CusSex,
                CusCard = CusCard,
                CusTel = CusTel
            };
            return Json(Bll_Customers.Insert(info));
        }
        public ActionResult Update(int CusID, string CusName, string CusSex, string CusCard, string CusTel)
        {
            Customers info = new Customers
            {
                CusID = CusID,
                CusName = CusName,
                CusSex = CusSex,
                CusCard = CusCard,
                CusTel = CusTel
            };
            return Json(Bll_Customers.Update(info));
        }
        public ActionResult Delete(int CusID)
        {
            return Json(Bll_Customers.Delete(CusID));
        }
    }
}