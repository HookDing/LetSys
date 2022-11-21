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
    public class HouseCategoryController : Controller
    {
        // GET: HouseCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetTree()
        {
            var list = Bll_HouseCategory.GetAllMod().Select(n => new
            {
                id = n.HCID,
                text = n.HCName,
            }).ToList();
            //创建树状列表
            var arr = new ArrayList();
            //向列表中添加数据(new{值,文本,子集})
            arr.Add(new { id = -1, text = "全部", children = list });
            return Json(arr);
        }
        public ActionResult GetAllMod()
        {
            var list = Bll_HouseCategory.GetAllMod().Select(n => new
            {
                id = n.HCID,
                text = n.HCName,
            }).ToList();
            list.Insert(0,new
            {
                id = 0,
                text = "请选择"
            });
            return Json(list);
        }
        public ActionResult GetMod(int HCID)
        {
            return Json(Bll_HouseCategory.GetMod(HCID));
        }
        public ActionResult Insert(Mod_HouseCategory info)
        {
            return Json(Bll_HouseCategory.Insert(info));
        }
        public ActionResult Update(Mod_HouseCategory info)
        {
            return Json(Bll_HouseCategory.Update(info));
        }
        public ActionResult Delete(int HCID)
        {
            return Json(Bll_HouseCategory.Delete(HCID));
        }
    }
}