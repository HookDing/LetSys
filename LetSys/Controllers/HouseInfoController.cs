using Bll;
using Mod;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetSys.Controllers
{
    public class HouseInfoController : Controller
    {
        // GET: HouseInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LetView(int HID)
        {
            ViewBag.HID = HID;
            return View();
        }
        public ActionResult AddPayView(int id)
        {
            ViewBag.id = id;
            return View();
        }
        
        public ActionResult GetPageMod(int page, int rows, Mod_HouseInfo info)
        {
            int count;
            if (info == null)
            {
                info = new Mod_HouseInfo();
            }
            var list = Bll_HouseInfo.GetPageMod(page, rows, info, out count);
            return Json(new { rows = list, total = count });

        }
        public ActionResult GetMod(int HID)
        {
            return Json(Bll_HouseInfo.GetMod(HID));
        }
        public ActionResult Insert(Mod_HouseInfo info)
        {
            return Json(Bll_HouseInfo.Insert(info));
        }
        public ActionResult Update(Mod_HouseInfo info)
        {
            return Json(Bll_HouseInfo.Update(info));
        }
        public ActionResult Delete(int HID)
        {
            return Json(Bll_HouseInfo.Delete(HID));
        }
    }
}