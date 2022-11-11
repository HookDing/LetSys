using Dal;
using Mod;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Bll_PayInfo
    {
        public static List<Mod_PayInfo> GetAllMod()
        {
            using (LetDB db = new LetDB())
            {
                return db.PayInfo.Where(n => n.PayState > 0)
                    .Select(n => new Mod_PayInfo
                    {
                        PayID = n.PayID,
                        PayNum = n.PayNum,
                        PayBeginDate = n.PayBeginDate,
                        PayEndDate = n.PayEndDate,
                        PayPrice = n.PayPrice,
                        PayAmount = n.PayAmount,
                        PayMoney1 = n.PayMoney1,
                        PayMoney2 = n.PayMoney2,
                        PayState = n.PayState,
                        CCName = n.ChargeCategory.CCName,
                        EmpName = n.Lets.Employs.EmpName,
                        CusName = n.Lets.Customers.CusName,
                        CreateEmp = n.CreateEmp,
                        LetID = n.LetID,
                        CCID = n.CCID,
                        HNum = n.Lets.HouseInfo.HNum,
                    }).ToList();
            }
        }
        public static List<Mod_PayInfo> GetPayInfoMod(int PayID)
        {
            using (LetDB db = new LetDB())
            {
                return db.PayInfo.Where(n => n.PayState > 0 && n.PayID == PayID)
                    .Select(n => new Mod_PayInfo
                    {
                        PayID = n.PayID,
                        PayNum = n.PayNum,
                        PayBeginDate = n.PayBeginDate,
                        PayEndDate = n.PayEndDate,
                        PayPrice = n.PayPrice,
                        PayAmount = n.PayAmount,
                        PayMoney1 = n.PayMoney1,
                        PayMoney2 = n.PayMoney2,
                        PayState = n.PayState,
                        CCName = n.ChargeCategory.CCName,
                        EmpName = n.Lets.Employs.EmpName,
                        CusName = n.Lets.Customers.CusName,
                        CreateEmp = n.CreateEmp,
                        LetID = n.LetID,
                        CCID = n.CCID,
                        HNum = n.Lets.HouseInfo.HNum,
                    }).ToList();
            }
        }
        public static void UpdateList(List<Mod_PayInfo> list)
        {
            using (LetDB db = new LetDB())
            {
                foreach (var item in list)
                {
                    //获取缴费记录
                    var payinfo = db.PayInfo.Find(item.PayID);
                    //计算实缴金额
                    payinfo.PayMoney2 = item.PayMoney2;
                    //计算缴费状态
                    if (payinfo.PayMoney1 == payinfo.PayMoney2)
                    {
                        payinfo.PayState = 3;//已缴费
                        //获取缴费科目判断是否要修改租赁信息中的日期
                        var cinfo = payinfo.ChargeCategory;
                        if ((bool)cinfo.ISDate)
                        {
                            //改变租赁信息(更改日期)
                            string sql = "update Lets set " + cinfo.CDateColumn + "=@date where LetID = @id";
                            SqlParameter[] param = new SqlParameter[] {
                                new SqlParameter("@date",payinfo.PayEndDate),
                                new SqlParameter("@id",payinfo.PayID),
                            };
                            db.Database.ExecuteSqlCommand(sql, param);
                        }
                        else
                        {
                            payinfo.PayState = 2;//缴费中
                        }
                        db.Entry(payinfo).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
        }
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool Insert(PayInfo info)
        {
            using (LetDB db = new LetDB())
            {
                db.PayInfo.Add(info);
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool Update(PayInfo info)
        {
            using (LetDB db = new LetDB())
            {
                db.Entry(info).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 更改状态为删除
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool Delete(PayInfo info)
        {
            using (LetDB db = new LetDB())
            {
                info.PayState = 0;
                db.Entry(info).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
    }
}
