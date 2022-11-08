using Bll;
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
            return Json(Bll_Customers.Insert(CusName,CusSex,CusCard,CusTel));
        }
        public ActionResult Update(int CusID, string CusName, string CusSex, string CusCard, string CusTel)
        {
            return Json(Bll_Customers.Update(CusID,CusName,CusSex,CusCard,CusTel));
        }
        public ActionResult Delete(int CusID)
        {
            return Json(Bll_Customers.Delete(CusID));
        }
    }
}