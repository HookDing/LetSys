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
        // GET: Customers/Index
        public ActionResult Index()
        {
            return View();
        }
        // GET: Customers/GetAllMod
        public ActionResult GetAllMod()
        {
            return Json(Bll_Customers.GetAllMod());
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