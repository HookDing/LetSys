using Dal;
using Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Bll_ChargeCategory
    {
        public static List<Mod_ChargeCategory> GetAllMod()
        {
            using (LetDB db = new LetDB())
            {
                return db.ChargeCategory.Where(n => n.CCState == true)
                    .Select(n => new Mod_ChargeCategory
                    {
                        CCID = n.CCID,
                        CCMark = n.CCMark,
                        CCName = n.CCName,
                        CCColumn1 = n.CCColumn1,
                        CCColumn2 = n.CCColumn2,
                        CCState = n.CCState,
                        CDateColumn = n.CDateColumn,
                        ISDate = n.ISDate
                    }).ToList();
            }
        }
        public static Mod_ChargeCategory GetMod(int CCID)
        {
            using (LetDB db = new LetDB())
            {
                return db.ChargeCategory.Where(n => n.CCState == true && n.CCID == CCID)
                    .Select(n => new Mod_ChargeCategory
                    {
                        CCID = n.CCID,
                        CCMark = n.CCMark,
                        CCName = n.CCName,
                        CCColumn1 = n.CCColumn1,
                        CCColumn2 = n.CCColumn2,
                        CCState = n.CCState,
                        CDateColumn = n.CDateColumn,
                        ISDate = n.ISDate,
                    }).ToList()[0];
            }
        }
        public static bool Insert(Mod_ChargeCategory info)
        {
            using (LetDB db = new LetDB())
            {
                db.ChargeCategory.Add(new ChargeCategory
                {
                    CCID = info.CCID,
                    CCColumn1 = info.CCColumn1,
                    CCColumn2 = info.CCColumn2,
                    CCState = true,//初始化状态
                    CDateColumn = info.CDateColumn,
                    CCMark = info.CCMark,
                    CCName = info.CCName,
                    ISDate = info.ISDate,
                });
                return db.SaveChanges() > 0;
            }
        }
        public static bool Update(Mod_ChargeCategory info)
        {
            using (LetDB db = new LetDB())
            {
                db.Entry(new Mod_ChargeCategory
                {
                    CCID = info.CCID,
                    CCColumn1 = info.CCColumn1,
                    CCColumn2 = info.CCColumn2,
                    CCState = info.CCState,
                    CDateColumn = info.CDateColumn,
                    CCMark = info.CCMark,
                    CCName = info.CCName,
                    ISDate = info.ISDate,
                }).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        public static bool Delete(int CCID)
        {
            using (LetDB db = new LetDB())
            {
                var mod = db.ChargeCategory.Find(CCID);
                mod.CCState = false;
                db.Entry(mod).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
    }
}
