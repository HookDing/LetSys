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
        public static bool Insert(string CusName, string CusSex, string CusCard, string CusTel)
        {
            using (LetDB db = new LetDB())
            {
                Customers info = new Customers
                {
                    CusName = CusName,
                    CusSex = CusSex,
                    CusCard = CusCard,
                    CusTel = CusTel
                };
                db.Customers.Add(info);
                return db.SaveChanges() > 0;
            }
        }
        public static bool Update(int CusID, string CusName, string CusSex, string CusCard, string CusTel)
        {
            using (LetDB db = new LetDB())
            {
                Customers info = new Customers
                {
                    CusID = CusID,
                    CusName = CusName,
                    CusSex = CusSex,
                    CusCard = CusCard,
                    CusTel = CusTel
                };
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
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
