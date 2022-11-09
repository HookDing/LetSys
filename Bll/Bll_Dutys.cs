using Dal;
using Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Bll_Dutys
    {
        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <returns>List<Mod_Dutys></returns>
        public static List<Mod_Dutys> GetAllMod()
        {
            using (LetDB db = new LetDB())
            {
                return db.Dutys.Where(t=>t.DutyState==true).Select(n => new Mod_Dutys
                {
                    DutyID = n.DutyID,
                    DutyName = n.DutyName,
                    DutyMark = n.DutyMark,
                    DutyState = n.DutyState,
                }).ToList();
            }
        }
        /// <summary>
        /// 根据ID查询并返回一条记录
        /// </summary>
        /// <param name="id">传入ID</param>
        /// <returns>Mod_Dutys</returns>
        public static Mod_Dutys GetMod(int id)
        {
            using (LetDB db = new LetDB())
            {
                return db.Dutys.Where(t=>t.DutyState==true && t.DutyID==id).Select(n => new Mod_Dutys
                {
                    DutyID = n.DutyID,
                    DutyName = n.DutyName,
                    DutyMark = n.DutyMark,
                    DutyState = n.DutyState,
                }).ToList()[0];
            }
        }
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool Insert(Dutys info)
        {
            using (LetDB db=new LetDB ())
            {
                db.Dutys.Add(info);
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool Update(Dutys info)
        {
            using (LetDB db =new LetDB())
            {
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="DutyID"></param>
        /// <returns></returns>
        public static bool Delete(int DutyID)
        {
            using (LetDB db =new LetDB())
            {
                Dutys info = db.Dutys.Find(DutyID);
                info.DutyState = false;
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
    }
}
