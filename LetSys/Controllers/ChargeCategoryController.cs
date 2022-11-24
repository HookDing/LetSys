using Bll;
using Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetSys.Controllers
{
    public class ChargeCategoryController : Controller
    {
        // GET: ChargeCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllMod()
        {
            return Json(Bll_ChargeCategory.GetAllMod());
        }
        public ActionResult GetMod(int id)
        {
            return Json(Bll_ChargeCategory.GetMod(id));
        }
        public ActionResult Insert(Mod_ChargeCategory info)
        {
            return Json(Bll_ChargeCategory.Insert(info));
        }
        public ActionResult Update(Mod_ChargeCategory info)
        {
            return Json(Bll_ChargeCategory.Update(info));
        }
        public ActionResult Delete(int id)
        {
            return Json(Bll_ChargeCategory.Delete(id));
        }
    }
}