using Dal;
using Mod;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Bll_HouseCategory
    {
        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        public static List<Mod_HouseCategory> GetAllMod()
        {
            using(LetDB db=new LetDB())
            {
                return db.HouseCategory
                    .Where(n => n.HCState == true)
                    .Select(n => new Mod_HouseCategory
                {
                    HCID = n.HCID,
                    HCMark = n.HCMark,
                    HCName = n.HCName,
                    HCState = n.HCState,
                }).ToList();
            }
        }
        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="HCID">房屋类型ID</param>
        /// <returns></returns>
        public static Mod_HouseCategory GetMod(int HCID)
        {
            using (LetDB db = new LetDB())
            {
                return db.HouseCategory
                    .Where(n => n.HCState == true && n.HCID == HCID)
                    .Select(n => new Mod_HouseCategory
                    {
                        HCID = n.HCID,
                        HCMark = n.HCMark,
                        HCName = n.HCName,
                        HCState = n.HCState,
                    }).ToList()[0];

            }
        }
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool Insert(Mod_HouseCategory info)
        {
            //设置默认状态
            info.HCState= true;
            using(LetDB db =new LetDB())
            {
                db.HouseCategory.Add(new HouseCategory
                {
                    HCID = info.HCID,
                    HCMark = info.HCMark,
                    HCName = info.HCName,
                    HCState = info.HCState,
                });
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool Update(Mod_HouseCategory info)
        {
            using(LetDB db =new LetDB())
            {
                var mod= new HouseCategory
                {
                    HCID = info.HCID,
                    HCMark = info.HCMark,
                    HCName = info.HCName,
                    HCState = info.HCState,
                };
                db.Entry(mod).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="HCID"></param>
        /// <returns></returns>
        public static bool Delete(int HCID)
        {
            using(LetDB db =new LetDB())
            {
                var mod = db.HouseCategory.Find(HCID);
                mod.HCState = false;
                db.Entry(mod).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
    }
}
