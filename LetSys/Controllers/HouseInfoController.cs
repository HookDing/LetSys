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
    }
}