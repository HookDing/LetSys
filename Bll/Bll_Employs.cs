using BLL;
using Dal;
using Mod;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        /// <summary>
        /// 分页查询并返回数据
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="pageSize">页面数据量</param>
        /// <param name="info">查询条件</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public static List<Mod_Employs> GetPageMod(int index, int pageSize, Mod_Employs info, out int count)
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
                var list = where
                    .OrderByDescending(n => n.EmpID)
                    .Skip((index - 1) * pageSize)
                    .Take(pageSize)
                    .Select(n => new Mod_Employs
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
                count = where.Count();
                return list;
            }
        }
        /// <summary>
        /// 根据ID查询并返回一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns>返回一条数据</returns>
        public static Mod_Employs GetMod(int id)
        {
            using (LetDB db = new LetDB())
            {
                return db.Employs
                    .Where(n => n.EmpID == id)
                    .Select(n => new Mod_Employs
                    {
                        EmpID = n.EmpID,
                        EmpMark = n.EmpMark,
                        EmpName = n.EmpName,
                        EmpAdd = n.EmpAdd,
                        EmpSex = n.EmpSex,
                        EmpState = n.EmpState,
                        EmpTel = n.EmpTel,
                        LoginName = n.LoginName,
                        DepID = n.DepID,
                        DutyID = n.DutyID,
                    }).ToList()[0];
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns>返回true/false</returns>
        public static bool Insert(Mod_Employs info)
        {
            using (LetDB db = new LetDB())
            {
                db.Employs.Add(new Employs
                {
                    EmpAdd = info.EmpAdd,
                    EmpMark = info.EmpMark,
                    EmpName = info.EmpName,
                    EmpSex = info.EmpSex,
                    EmpTel = info.EmpTel,
                    DepID = info.DepID,
                    DutyID = info.DutyID,
                    LoginName = info.LoginName,
                    //初始密码
                    LoginPWD = MD5Service.GetMD5CodeToString("111111"),
                    //状态(默认在职)
                    EmpState = 1,
                });
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns>返回true/false</returns>
        public static bool Update(Mod_Employs info)
        {
            using (LetDB db = new LetDB())
            {
                db.Entry(new Employs
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
                }).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 编辑员工状态( 0:删除 1:在职 2:离职 3:退休 )
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool EditState(Mod_Employs info)
        {
            Employs data = new Employs { EmpID = info.EmpID };
            using (LetDB db = new LetDB())
            {
                db.Employs.Attach(data);
                data.EmpState = info.EmpState;
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 重置员工登录密码为“111111”
        /// </summary>
        /// <param name="EmpID"></param>
        /// <returns>重置员工登录密码为：111111</returns>
        public static bool InitPwd(int EmpID)
        {
            Employs data = new Employs { EmpID = EmpID };
            using (LetDB db = new LetDB())
            {
                db.Employs.Attach(data);
                data.LoginPWD = MD5Service.GetMD5CodeToString("111111");
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 糢糊查询并返回5条记录，用于自动补全
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<Mod_Employs> GetCGData(string value)
        {
            using (LetDB db = new LetDB())
            {
                return db.Employs.Where(n => n.EmpState > 0 && n.EmpName.Contains(value))
                    .Take(5).Select(n => new Mod_Employs
                    {
                        DepID = n.DepID,
                        EmpName = n.EmpName,
                        LoginName = n.LoginName,
                        DepName = n.Departments.DepName,
                        DutyName = n.Dutys.DutyName,
                    }).ToList();
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="DepID"></param>
        /// <returns>成功为true，失败为false</returns>
        public static bool Delete(int DepID)
        {
            using (LetDB db = new LetDB())
            {
                var info = db.Employs.Find(DepID);
                info.EmpState = 0;
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 查询验证员工是否有权限访问请求的
        /// </summary>
        /// <param name="value">权限值</param>
        /// <param name="id">员工编号</param>
        /// <returns>返回true/false</returns>
        public static bool ValidateUser(string value, int id)
        {
            using (LetDB db = new LetDB())
            {
                //查询验证员工是否有权限访问请求的action
                string sql = @"select * from Jurisdictions where JurID in(
select jurid from jurisdicDuty where DutyID=(
select DutyID from Employs where empid =@id))
and jurValue=@value";
                SqlParameter[] parm = {
                    new SqlParameter("@id", id),
                    new SqlParameter("@value", value),
                };
                //SqlParameter p1 = new SqlParameter("@id", id);
                //SqlParameter p2 = new SqlParameter("@value", value);
                var list = db.Database.SqlQuery<Jurisdictions>(sql, parm);
                return list.Count() > 0;
            }
        }
    }
}
