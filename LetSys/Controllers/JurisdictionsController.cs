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
        // GET: Jurisdictions/Index
        public ActionResult Index()
        {
            return View();
        }
        // GET: Jurisdictions/GetAllMod
        public ActionResult GetAllMod()
        {
            return Json(Bll_Jurisdictions.GetAllMod());
        }
        // POST: Jurisdictions/GetMod
        public ActionResult GetMod(int id)
        {
            return Json(Bll_Jurisdictions.GetMod(id));
        }
        // POST: Jurisdictions/Insert
        public ActionResult Insert(Jurisdictions info)
        {
            info.JurState = 1;
            return Json(Bll_Jurisdictions.Insert(info));
        }
        // POST: Jurisdictions/Update
        public ActionResult Update(Jurisdictions info)
        {
            info. JurState = 1;
            return Json(Bll_Jurisdictions.Update(info));
        }
        // POST: Jurisdictions/Delete
        public ActionResult Delete(int JurID)
        {
            return Json(Bll_Jurisdictions.Delete(JurID));
        }
    }
}