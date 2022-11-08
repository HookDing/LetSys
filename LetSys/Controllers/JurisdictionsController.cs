using Bll;
using Dal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetSys.Controllers
{
    public class JurisdictionsController : Controller
    {
        // GET: Jurisdictions
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllMod()
        {
            return Json(Bll_Jurisdictions.GetAllMod());
        }
        public ActionResult GetMod(int id)
        {
            return Json(Bll_Jurisdictions.GetMod(id));
        }
        public ActionResult Insert(string JurName, string JurValue)
        {
            Jurisdictions info = new Jurisdictions { JurName = JurName, JurValue = JurValue, JurState = 1 };
            return Json(Bll_Jurisdictions.Insert(info));
        }
        public ActionResult Update(int JurID, string JurName, string JurValue)
        {
            Jurisdictions info = new Jurisdictions { JurID = JurID, JurName = JurName, JurValue = JurValue, JurState = 1 };
            return Json(Bll_Jurisdictions.Update(info));
        }
        public ActionResult Delete(int JurID)
        {
            return Json(Bll_Jurisdictions.Delete(JurID));
        }
    }
}