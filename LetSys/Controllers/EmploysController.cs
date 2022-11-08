using Bll;
using Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetSys.Controllers
{
    public class EmploysController : Controller
    {
        // GET: Employs
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetModPage(int index, int pagesize, Mod_Employs info)
        {
            index = 1;
            pagesize = 5;
            return Json(Bll_Employs.GetModPage(index, pagesize, info, out int count));
        }
        public ActionResult GetAllMod()
        {
            var a = Bll_Employs.GetAllMod();
            return Json(a);
        }
    }
}