using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetSys.Controllers
{
    public class PayInfoController : Controller
    {
        // GET: PayInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllMod()
        {
            return Json(Bll_PayInfo.GetAllMod());
        }
        public ActionResult GetMod(int payID)
        {
            return Json(Bll_PayInfo.GetMod(payID));
        }
    }
}