using Bll;
using Dal;
using Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetSys.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers/Index
        public ActionResult Index()
        {
            return View();
        }
        // GET: Customers/GetPageMod
        public ActionResult GetPageMod(int page, int rows, Mod_Customers info)
        {
            int count;
            if (info == null)
            {
                info = new Mod_Customers();
            }
            var list = Bll_Customers.GetPageMod(page, rows, info, out count);
            return Json(new { rows = list, total = count });
        }
        // POST: Customers/GetMod
        public ActionResult GetMod(int id)
        {
            return Json(Bll_Customers.GetMod(id));
        }
        // POST: Customers/Insert
        public ActionResult Insert(Customers info)
        {
            return Json(Bll_Customers.Insert(info));
        }
        // POST: Customers/Update
        public ActionResult Update(Customers info)
        {
            return Json(Bll_Customers.Update(info));
        }
        // POST: Customers/Delete
        public ActionResult Delete(int CusID)
        {
            return Json(Bll_Customers.Delete(CusID));
        }
    }
}