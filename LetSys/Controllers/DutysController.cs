using Bll;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetSys.Controllers
{
    public class DutysController : Controller
    {
        // GET: Dutys/Index
        public ActionResult Index()
        {
            return View();
        }
        // GET: Dutys/GetAllMod
        public ActionResult GetAllMod()
        {
            return Json(Bll_Dutys.GetAllMod());
        }
        // GET: Dutys/GetAllList
        public ActionResult GetAllList()
        {
            var list = Bll_Dutys.GetAllMod();
            list.Insert(0, new Mod.Mod_Dutys { DutyID = 0, DutyName = "全部" });
            return Json(list);
        }
        // GET: Dutys/GetMod
        public ActionResult GetMod(int id)
        {
            return Json(Bll_Dutys.GetMod(id));
        }
        // GET: Dutys/Insert
        public ActionResult Insert(Dutys info)
        {
            info.DutyState = true;
            return Json(Bll_Dutys.Insert(info));
        }
        // GET: Dutys/Update
        public ActionResult Update(Dutys info)
        {
            return Json(Bll_Dutys.Update(info));
        }
        // GET: Dutys/Delete
        public ActionResult Delete(int DutyID)
        {
            return Json(Bll_Dutys.Delete(DutyID));
        }
    }
}