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
        // GET: Dutys
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllMod()
        {
            return Json(Bll_Dutys.GetAllMod());
        }
        public ActionResult GetMod(int id)
        {
            return Json(Bll_Dutys.GetMod(id));
        }
        public ActionResult Insert(string DutyName, string DutyMark)
        {
            Dutys info = new Dutys { DutyName=DutyName,DutyMark= DutyMark,DutyState=true };
            return Json(Bll_Dutys.Insert(info));
        }
        public ActionResult Update(int DutyID,string DutyName, string DutyMark)
        {
            Dutys info = new Dutys {DutyID=DutyID, DutyName = DutyName, DutyMark = DutyMark,DutyState=true  };
            return Json(Bll_Dutys.Update(info));
        }
        public ActionResult Delete(int DutyID)
        {
            return Json(Bll_Dutys.Delete(DutyID));
        }
    }
}