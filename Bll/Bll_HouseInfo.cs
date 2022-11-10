using Dal;
using Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Bll_HouseInfo
    {
        /// <summary>
        /// 获取所有记录(可根据类型HCID查询)
        /// </summary>
        /// <returns></returns>
        public static List<Mod_HouseInfo> GetPageMod(int page, int size, Mod_HouseInfo info, out int count)
        {
            using (LetDB db = new LetDB())
            {
                var where = db.HouseInfo.Where(n => n.HState > 0);
                if (info.HCID > -1)
                {
                    where = where.Where(n => n.HCID == info.HCID);
                }
                var list = where.OrderByDescending(n => n.HID).Skip((page - 1) * size).Take(size)
                  .Select(n => new Mod_HouseInfo
                  {
                      HID = n.HID,
                      HAdd = n.HAdd,
                      HArea = n.HArea,
                      HDirection = n.HDirection,
                      HMark = n.HMark,
                      HNet = n.HNet,
                      HNum = n.HNum,
                      HRent = n.HRent,
                      HType = n.HType,
                      HElectric = n.HElectric,
                      HElectricMoney = n.HElectricMoney,
                      HWater = n.HWater,
                      HWaterMoney = n.HWaterMoney,
                      HState = n.HState,
                      HCID = n.HCID,
                      HCName = n.HouseCategory.HCName,
                  }).ToList();
                count = where.Count();
                return list;
            }
        }
        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="HCID">房屋类型ID</param>
        /// <returns></returns>
        public static Mod_HouseInfo GetMod(int HID)
        {
            using (LetDB db = new LetDB())
            {
                return db.HouseInfo
                    .Where(n => n.HState > 0 && n.HID == HID)
                    .Select(n => new Mod_HouseInfo
                    {
                        HID = n.HID,
                        HAdd = n.HAdd,
                        HArea = n.HArea,
                        HDirection = n.HDirection,
                        HMark = n.HMark,
                        HNet = n.HNet,
                        HNum = n.HNum,
                        HRent = n.HRent,
                        HType = n.HType,
                        HElectric = n.HElectric,
                        HElectricMoney = n.HElectricMoney,
                        HWater = n.HWater,
                        HWaterMoney = n.HWaterMoney,
                        HState = n.HState,
                        HCID = n.HCID,
                        HCName = n.HouseCategory.HCName,
                    }).ToList()[0];

            }
        }
    }
}
