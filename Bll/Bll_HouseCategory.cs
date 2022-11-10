using Dal;
using Mod;
using System;
using System.Collections.Generic;
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
            using(LetDB db=new LetDB())
            {
                return db.HouseCategory
                    .Where(n => n.HCState == true && n.HCID== HCID)
                    .Select(n => new Mod_HouseCategory
                {
                    HCID = n.HCID,
                    HCMark = n.HCMark,
                    HCName = n.HCName,
                    HCState = n.HCState,
                }).ToList()[0];

            }
        }
    }
}
