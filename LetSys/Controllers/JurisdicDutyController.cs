using Bll;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetSys.Controllers
{
    public class JurisdicDutyController : Controller
    {
        // GET: JurisdicDuty/Index
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllMod()
        {
            return Json(Bll_JurisdicDuty.GetAllMod());
        }
        public ActionResult GetModsByDutyID(int DutyID)
        {
            return Json(Bll_JurisdicDuty.GetModsByDutyID(DutyID));
        }
        public ActionResult Insert(JurisdicDuty info)
        {
            return Json(Bll_JurisdicDuty.Insert(info));
        }
        public ActionResult Update(JurisdicDuty info)
        {
            return Json(Bll_JurisdicDuty.Update(info));
        }
        public ActionResult GetAllMod(int JDID)
        {
            return Json(Bll_JurisdicDuty.Delete(JDID));
        }
    }
}