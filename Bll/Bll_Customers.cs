using Dal;
using Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Bll_Customers
    {
        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        public static List<Mod_Customers> GetAllMod()
        {
            using (LetDB db = new LetDB())
            {
                return db.Customers
                    .Where(t => t.CusState > 0)
                    .Select(n => new Mod_Customers
                    {
                        CusID = n.CusID,
                        CusName = n.CusName,
                        CusSex = n.CusSex,
                        CusCard = n.CusCard,
                        CusState = n.CusState,
                        CusTel = n.CusTel
                    }).ToList();
            }
        }
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="id">CusID</param>
        /// <returns></returns>
        public static Mod_Customers GetMod(int id)
        {
            using (LetDB db = new LetDB())
            {
                return db.Customers
                    .Where(n => n.CusID == id && n.CusState > 0)
                    .Select(n => new Mod_Customers
                    {
                        CusID = n.CusID,
                        CusName = n.CusName,
                        CusSex = n.CusSex,
                        CusCard = n.CusCard,
                        CusTel = n.CusTel,
                        CusState = n.CusState,
                    }).ToList()[0];
            }
        }
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool Insert(Customers info)
        {
            using (LetDB db = new LetDB())
            {
                db.Customers.Add(info);
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool Update(Customers info)
        {
            using (LetDB db = new LetDB())
            {
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="CusID"></param>
        /// <returns></returns>
        public static bool Delete(int CusID)
        {
            using (LetDB db = new LetDB())
            {
                Customers info = db.Customers.Find(CusID);
                info.CusState = 0;
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
    }
}
