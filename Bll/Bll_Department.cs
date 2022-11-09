using Dal;
using Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Bll_Department
    {
        /// <summary>
        /// 查询并返回全部数据
        /// </summary>
        /// <returns>List<Mod_Departments></returns>
        public static List<Mod_Departments> GetAllMod()
        {
            using (LetDB db = new LetDB())
            {
                return db.Departments
                    .Where(n => n.DepState == true)
                    .Select(n => new Mod_Departments
                    {
                        DepID = n.DepID,
                        DepName = n.DepName,
                        DepMark = n.DepMark,
                        DepState = n.DepState
                    }).ToList();
            }
        }
        /// <summary>
        /// 根据ID查询并返回一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Mod_Departments</returns>
        public static Mod_Departments GetMod(int id)
        {
            using (LetDB db = new LetDB())
            {
                return db.Departments
                    .Where(n => n.DepID == id)
                    .Select(n => new Mod_Departments
                    {
                        DepID = n.DepID,
                        DepName = n.DepName,
                        DepMark = n.DepMark,
                        DepState = n.DepState
                    })
                    .ToList()[0];
            }
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <returns>成功为true，失败为false</returns>
        public static bool Insert(Departments info)
        {
            using (LetDB db = new LetDB())
            {
                info.DepState = true;
                db.Departments.Add(info);
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <returns>成功为true，失败为false</returns>
        public static bool Update(Departments info)
        {
            Departments data = new Departments { DepID = info.DepID };
            using (LetDB db = new LetDB())
            {
                db.Departments.Attach(data);
                data.DepName = info.DepName;
                data.DepMark = info.DepMark;
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="DepID"></param>
        /// <returns>成功为true，失败为false</returns>
        public static bool Delete(int DepID)
        {
            Departments data=new Departments { DepID = DepID };
            using (LetDB db = new LetDB())
            {
                db.Departments.Attach(data);
                data.DepState = false;
                return db.SaveChanges() > 0;
            }
        }
    }
}
