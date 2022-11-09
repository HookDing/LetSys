using Bll;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Let.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department/Index
        public ActionResult Index()
        {
            return View();
        }
        // GET: Department/GetAllMod
        public ActionResult GetAllMod()
        {
            return Json(Bll_Department.GetAllMod());
        }
        // GET: Department/GetAllList
        public ActionResult GetAllList()
        {
            var list = Bll_Department.GetAllMod();
            list.Insert(0, new Mod.Mod_Departments { DepID = -1, DepName = "全部" });
            return Json(list);
        }
        // POST: Department/GetMod
        public ActionResult GetMod(int id)
        {
            return Json(Bll_Department.GetMod(id));
        }
        // POST: Department/Insert
        public ActionResult Insert(Departments info)
        {
            return Json(Bll_Department.Insert(info));
        }
        // POST: Department/Update
        public ActionResult Update(Departments info)
        {
            return Json(Bll_Department.Update(info));
        }
        // POST: Department/Delete
        public ActionResult Delete(int DepID)
        {
            return Json(Bll_Department.Delete(DepID));
        }
    }
}