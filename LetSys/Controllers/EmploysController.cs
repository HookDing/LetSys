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
        public ActionResult GetModPage(int pageNumber, int pagesize, Mod_Employs info, out int count)
        {
            pageNumber = 1;
            pagesize = 5;
            count = 0;
            ViewBag.Count= count;
            ViewBag.PageSize=pagesize;
            return Json(Bll_Employs.GetModPage(pageNumber, pagesize, info,out count));
        }
        public ActionResult GetAllMod()
        {
            var a = Bll_Employs.GetAllMod();
            return Json(a);
        }
    }
}