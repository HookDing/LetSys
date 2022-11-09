using Bll;
using Dal;
using Mod;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace LetSys.Controllers
{
    public class EmploysController : Controller
    {
        // GET: Employs
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPageMod(int page, int rows, Mod_Employs info)
        {
            int count;
            if (info==null)
            {
                info = new Mod_Employs();
            }
            var list =Bll_Employs.GetPageMod(page,rows,info,out count);
            return Json(new {rows=list,total=count});
        }

        public ActionResult GetMod(int EmpID)
        {
            return Json(Bll_Employs.GetMod(EmpID));
        }

        public ActionResult Insert(Mod_Employs info)
        {
            return Json(Bll_Employs.Insert(info));
        }
        public ActionResult Update(Mod_Employs info)
        {
            return Json(Bll_Employs.Update(info));
        }
        public ActionResult InitPwd(int EmpID)
        {
            return Json(Bll_Employs.InitPwd(EmpID));
        }
        public ActionResult EditState(Mod_Employs info)
        {
            return Json(Bll_Employs.EditState(info));
        }
        public ActionResult Delete(int EmpID)
        {
            return Json(Bll_Employs.Delete(EmpID));
        }
    }
}