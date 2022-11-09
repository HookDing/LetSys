using Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Bll_JurisdicDuty
    {
        public static List<JurisdicDuty> GetAllMod()
        {
            using (LetDB db=new LetDB())
            {
                return db.JurisdicDuty.ToList();
            }
        }
        public static List<JurisdicDuty> GetModsByDutyID(int DutyID)
        {
            using (LetDB db=new LetDB())
            {
                return db.JurisdicDuty.Where(n=>n.DutyID== DutyID).ToList();
            }
        }
        public static bool Insert(JurisdicDuty info)
        {
            using(LetDB db=new LetDB())
            {
                db.JurisdicDuty.Add(info);
                return db.SaveChanges() > 0;
            }
        }
        public static bool Update(JurisdicDuty info)
        {
            using(LetDB db=new LetDB())
            {
                db.Entry(info).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        public static bool Delete(int JDID)
        {
            using(LetDB db=new LetDB())
            {
                db.JurisdicDuty.Remove(db.JurisdicDuty.Find(JDID));
                return db.SaveChanges() > 0;
            }
        }
    }
}
