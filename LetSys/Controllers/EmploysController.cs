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
        // GET: Employs/Index
        public ActionResult Index()
        {
            return View();
        }
        // GET: Employs/GetPageMod
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
        // GET: Employs/GetAllMod
        public ActionResult GetAllMod()
        {
            return Json(Bll_Employs.GetAllMod());
        }
        // GET: Employs/GetMod
        public ActionResult GetMod(int EmpID)
        {
            return Json(Bll_Employs.GetMod(EmpID));
        }
        // GET: Employs/Insert
        public ActionResult Insert(Mod_Employs info)
        {
            return Json(Bll_Employs.Insert(info));
        }
        // GET: Employs/Update
        public ActionResult Update(Mod_Employs info)
        {
            return Json(Bll_Employs.Update(info));
        }
        // GET: Employs/InitPwd
        public ActionResult InitPwd(int EmpID)
        {
            return Json(Bll_Employs.InitPwd(EmpID));
        }
        // GET: Employs/EditState
        public ActionResult EditState(Mod_Employs info)
        {
            return Json(Bll_Employs.EditState(info));
        }
        // GET: Employs/Delete
        public ActionResult Delete(int EmpID)
        {
            return Json(Bll_Employs.Delete(EmpID));
        }
    }
}