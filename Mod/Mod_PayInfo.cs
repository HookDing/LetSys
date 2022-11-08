using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod
{
    public class Mod_PayInfo
    {
        public int PayID { get; set; }

        public int? LetID { get; set; }

        public int? CCID { get; set; }

        public string PayNum { get; set; }

        public int? CreateEmp { get; set; }

        public DateTime? CreateDate { get; set; }

        public decimal? PayPrice { get; set; }

        public int? PayAmount { get; set; }

        public decimal? PayMoney1 { get; set; }

        public decimal? PayMoney2 { get; set; }

        public DateTime? PayBeginDate { get; set; }

        public DateTime? PayEndDate { get; set; }

        public string PayMark { get; set; }

        public int PayState { get; set; }

        public string HNum { get; set; }

        public string CusName { get; set; }

        public string CCName { get; set; }

        public string EmpName { get; set; }

    }
}
