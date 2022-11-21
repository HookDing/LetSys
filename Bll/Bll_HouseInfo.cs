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
                //条件查询
                //HAdd HNum HType HArea HState
                if (info.HAdd != null)
                {
                    where = where.Where(n => n.HAdd.Contains(info.HAdd));
                }
                if (info.HNum != null)
                {
                    where = where.Where(n => n.HNum == info.HNum);
                }
                if (info.HType != null)
                {
                    where = where.Where(n => n.HType.Contains(info.HType));
                }
                if (info.HArea != null)//范围查询
                {
                    where = where.Where(n => n.HArea > info.HArea);
                }
                if (info.HState != null)
                {
                    where = where.Where(n => n.HState == info.HState);
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
        public static bool Insert(Mod_HouseInfo info)
        {
            //设置初始状态
            info.HState = 1;
            using (LetDB db = new LetDB())
            {
                db.HouseInfo.Add(new HouseInfo
                {
                    HID = info.HID,
                    HAdd = info.HAdd,
                    HArea = info.HArea,
                    HDirection = info.HDirection,
                    HMark = info.HMark,
                    HNet = info.HNet,
                    HNum = info.HNum,
                    HRent = info.HRent,
                    HType = info.HType,
                    HElectric = info.HElectric,
                    HElectricMoney = info.HElectricMoney,
                    HWater = info.HWater,
                    HWaterMoney = info.HWaterMoney,
                    HState = info.HState,
                    HCID = info.HCID,
                });
                return db.SaveChanges() > 0;
            }
        }
        public static bool Update(Mod_HouseInfo info)
        {
            using (LetDB db = new LetDB())
            {
                var mod = new HouseInfo
                {
                    HID = info.HID,
                    HAdd = info.HAdd,
                    HArea = info.HArea,
                    HDirection = info.HDirection,
                    HMark = info.HMark,
                    HNet = info.HNet,
                    HNum = info.HNum,
                    HRent = info.HRent,
                    HType = info.HType,
                    HElectric = info.HElectric,
                    HElectricMoney = info.HElectricMoney,
                    HWater = info.HWater,
                    HWaterMoney = info.HWaterMoney,
                    HState = info.HState,
                    HCID = info.HCID,
                };
                db.Entry(mod).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        public static bool Delete(int HID)
        {
            using (LetDB db = new LetDB())
            {
                var mod = db.HouseInfo.Find(HID);
                mod.HState = 0;
                db.Entry(mod).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
    }
}
