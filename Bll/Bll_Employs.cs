using BLL;
using Dal;
using Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Bll_Employs
    {
        /// <summary>
        /// 登录并返回登录者信息
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>登录者信息：Mod_Employs</returns>
        public static Mod_Employs Login(string name, string pwd)
        {
            using (LetDB db = new LetDB())
            {
                //将用户输入的密码加密
                string Enpwd = MD5Service.GetMD5CodeToString(pwd);
                var queryList = db.Employs
                    .Where(e => e.LoginName == name && e.LoginPWD == Enpwd && e.EmpState == 1)
                    .Select(e => new Mod_Employs
                    {
                        LoginName = e.LoginName,
                        LoginPWD = e.LoginPWD,
                        EmpID = e.EmpID
                    })
                    .ToList();
                return queryList.Count() == 0 ? null : queryList[0];
            }
        }
        #region 常规查询(全部、单条)
        /// <summary>
        /// 查询并返回所有数据
        /// </summary>
        /// <returns></returns>
        public static List<Mod_Employs> GetAllMod()
        {
            using (LetDB db = new LetDB())
            {
                return db.Employs.Select(n => new Mod_Employs
                {
                    EmpAdd = n.EmpAdd,
                    EmpID = n.EmpID,
                    EmpMark = n.EmpMark,
                    EmpName = n.EmpName,
                    EmpSex = n.EmpSex,
                    EmpState = n.EmpState,
                    EmpTel = n.EmpTel,
                    DepID = n.DepID,
                    DepName = n.Departments.DepName,
                    DutyID = n.DutyID,
                    DutyName = n.Dutys.DutyName,
                    LoginName = n.LoginName,
                    LoginPWD = n.LoginPWD,
                }).ToList();
            }
        }
        ///// <summary>
        ///// 根据ID查询并返回一条数据
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public static Mod_Employs GetMod(int id)
        //{
        //    using (LetDB db = new LetDB())
        //    {
        //        return db.Employs.Select(n => new Mod_Employs
        //        {
        //            EmpAdd = n.EmpAdd,
        //            EmpID = n.EmpID,
        //            EmpMark = n.EmpMark,
        //            EmpName = n.EmpName,
        //            EmpSex = n.EmpSex,
        //            EmpState = n.EmpState,
        //            EmpTel = n.EmpTel,
        //            DepID = n.DepID,
        //            DepName = n.EmpName,
        //            DutyID = n.DutyID,
        //            DutyName = n.Dutys.DutyName,
        //            LoginName = n.LoginName,
        //            LoginPWD = n.LoginPWD,
        //        }).ToList()[0];
        //    }
        //}

        #endregion
        /// <summary>
        /// 分页查询并返回数据
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="pagesize">页面数据量</param>
        /// <param name="info">查询条件</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public static List<Mod_Employs> GetModPage(int index, int pagesize, Mod_Employs info, out int count)
        {
            using (LetDB db = new LetDB())
            {
                var where = db.Employs.Where(n => n.EmpState > 0);
                if (!string.IsNullOrWhiteSpace(info.EmpName))
                {
                    where = where.Where(n => n.EmpName.Contains(info.EmpName));
                }
                if (0 < info.DepID)
                {
                    where = where.Where(n => n.DepID == info.DepID);
                }
                if (0 < info.DutyID)
                {
                    where = where.Where(n => n.DutyID == info.DutyID);
                }
                var list = where.Select(n => new Mod_Employs
                {
                    DepID = n.DepID,
                    DepName = n.Departments.DepName,
                    DutyID = n.DutyID,
                    DutyName = n.Dutys.DutyName,
                    EmpAdd = n.EmpAdd,
                    EmpID = n.EmpID,
                    EmpMark = n.EmpMark,
                    EmpName = n.EmpName,
                    EmpSex = n.EmpSex,
                    EmpState = n.EmpState,
                    EmpTel = n.EmpTel,
                    LoginName = n.LoginName,
                    LoginPWD = n.LoginPWD,
                }).ToList();
                count = list.Count;
                return list;
            }
        }




        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool Insert(Mod_Employs info)
        {
            using (LetDB db = new LetDB())
            {
                db.Employs.Add(new Employs
                {
                    EmpAdd = info.EmpAdd,
                    EmpID = info.EmpID,
                    EmpMark = info.EmpMark,
                    EmpName = info.EmpName,
                    EmpSex = info.EmpSex,
                    EmpState = info.EmpState,
                    EmpTel = info.EmpTel,
                    DepID = info.DepID,
                    DutyID = info.DutyID,
                    LoginName = info.LoginName,
                    LoginPWD = info.LoginPWD,
                });
                return db.SaveChanges() > 0;
            }
        }
    }
}
