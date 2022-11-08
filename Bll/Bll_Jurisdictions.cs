using Dal;
using Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Bll_Jurisdictions
    {
        public static List<View_Jurisdictions> GetAllMod()
        {
            using (LetDB db =new LetDB ())
            {
                return db.Jurisdictions.Where(t=>t.JurState==1).Select(n=>new View_Jurisdictions
                {
                    JurID=n.JurID,
                    JurName=n.JurName,
                    JurValue=n.JurValue,
                }).ToList();
            }
        }
        public static View_Jurisdictions GetMod(int id)
        {
            using (LetDB db =new LetDB ())
            {
                return db.Jurisdictions.Where(t =>t.JurID==id && t.JurState == 1).Select(n => new View_Jurisdictions
                {
                    JurID = n.JurID,
                    JurName = n.JurName,
                    JurValue = n.JurValue,
                }).ToList()[0];
            }
        }
        public static bool Insert(Jurisdictions info)
        {
            using (LetDB db =new LetDB ())
            {
                db.Jurisdictions.Add(info);
                return db.SaveChanges()>0;
            }
        }
        public static bool Update(Jurisdictions info)
        {
            using (LetDB db =new LetDB ())
            {
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges()>0;
            }
        }
        public static bool Delete(int JurID)
        {
            using (LetDB db=new LetDB())
            {
                Jurisdictions info = db.Jurisdictions.Find(JurID);
                info.JurState = 0;
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
    }
}
