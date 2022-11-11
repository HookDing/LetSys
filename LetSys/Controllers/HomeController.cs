using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Let.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 登录窗体
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoLogin(string name, string pwd)
        {
            var user = Bll_Employs.Login(name, pwd);
            if (user == null)
            {
                TempData["msg"] = "用户名或密码错误！";
                TempData["url"] = "/Home/Login";
                //登录失败
                return RedirectToAction("Error");
            }
            else
            {
                Session["user"] = user;
                //登录成功
                return RedirectToAction("Index");
            }
        }
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 默认窗体
        /// </summary>
        /// <returns></returns>
        public ActionResult Default()
        {
            return View();
        }
        /// <summary>
        /// 错误页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            return View();
        }
        /// <summary>
        /// 安全退出
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login");
        }
    }
}